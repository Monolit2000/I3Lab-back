using AutoFixture;
using I3Lab.Modules.BlobFailes.Api;
using I3Lab.Treatments.Application.TreatmentFiles.CreateTreatmentFile;
using I3Lab.Treatments.Domain.TreatmentFiles;
using I3Lab.Treatments.Domain.TreatmentStages;
using NSubstitute;
using FluentResults;
using FluentAssertions;
using static I3Lab.Modules.BlobFailes.Api.IBlobFilesApi;
using System.Threading.Tasks;
using System.Threading;
using MassTransit.Futures.Contracts;
using MassTransit.Observables;

namespace I3Lab.Treatments.UnitTests.TreatmentFiles
{
    public class CreateTreatmentFileCommandHandlerTests : TreatmentTestsBase
    {
        private readonly Fixture _fixture;
        private readonly IBlobFilesApi _blobFilesApi;
        private readonly ITreatmentStageRepository _treatmentStageRepository;
        private readonly ITreatmentFileRepository _treatmentFileRepository;
        private readonly CreateTreatmentFileCommandHandler _handler;

        public CreateTreatmentFileCommandHandlerTests()
        {
            _fixture = new Fixture();

            //_fixture.Customize<CreateTreatmentFileCommand>(c =>
            //    c.With(x => x.Stream, new MemoryStream()));

            _blobFilesApi = Substitute.For<IBlobFilesApi>();
            _treatmentStageRepository = Substitute.For<ITreatmentStageRepository>();
            _treatmentFileRepository = Substitute.For<ITreatmentFileRepository>();

            _handler = new CreateTreatmentFileCommandHandler(_blobFilesApi, _treatmentStageRepository, _treatmentFileRepository);
        }

        [Fact]
        public async Task Handle_ShouldReturnError_WhenTreatmentStageNotFound()
        {
            // Arrange
            var command = GetValidCommand();
            _treatmentStageRepository.GetByIdAsync(Arg.Any<TreatmentStageId>(), Arg.Any<CancellationToken>())
                .Returns((TreatmentStage)null);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == "TreatmentStage not found");
        }

        [Fact]
        public async Task Handle_ShouldReturnError_WhenFileUploadFails()
        {
            // Arrange
            var command = GetValidCommand();
            var treatmentStage =  CreateTreatmentTestData(new TreatmentTestDataOptions()).TreatmentStage;

            _treatmentStageRepository.GetByIdAsync(Arg.Any<TreatmentStageId>(), Arg.Any<CancellationToken>())
                .Returns(treatmentStage);

            _blobFilesApi.UploadAsync(Arg.Any<string>(), Arg.Any<Stream>(), Arg.Any<string>())
                .Returns(Result.Fail("File upload failed"));

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == "File upload failed");
        }

        [Fact]
        public async Task Handle_ShouldReturnSuccess_WhenFileCreatedSuccessfully()
        {
            // Arrange
            var command = GetValidCommand();

            var treatmentStage = CreateTreatmentTestData(new TreatmentTestDataOptions()).TreatmentStage;

            _treatmentStageRepository.GetByIdAsync(Arg.Any<TreatmentStageId>(), Arg.Any<CancellationToken>())
                .Returns(treatmentStage);

            _blobFilesApi.UploadAsync(Arg.Any<string>(), Arg.Any<Stream>(), Arg.Any<string>())
                .Returns(Result.Ok(new BlobFileDto(Guid.NewGuid(), "http://example.com/file.jpg")));

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeTrue();
            await _treatmentFileRepository.Received(1).AddAsync(Arg.Any<TreatmentFile>(), Arg.Any<CancellationToken>());
            await _treatmentFileRepository.Received(1).SaveChangesAsync(Arg.Any<CancellationToken>());
            result.Value.Should().NotBeNull();
        }


        private CreateTreatmentFileCommand GetValidCommand()
        {
            var command = new CreateTreatmentFileCommand
            {
                WorkId = Guid.NewGuid(),
                FileName = "test.jpg",
                Stream = new MemoryStream(),
                ContentType = "image/jpeg"
            };

            return command;
        }
    }
}
