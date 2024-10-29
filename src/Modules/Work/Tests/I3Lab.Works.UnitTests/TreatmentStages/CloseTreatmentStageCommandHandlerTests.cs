using NSubstitute;
using AutoFixture;
using FluentAssertions;
using I3Lab.Treatments.Domain.TreatmentStages;
using I3Lab.Treatments.Application.TreatmentStages;
using I3Lab.Treatments.Application.TreatmentStages.CloseTreatmentStage;


namespace I3Lab.Treatments.UnitTests.TreatmentStages
{
    public class CloseTreatmentStageCommandHandlerTests : TreatmentTestsBase
    {
        private readonly Fixture _fixture;
        private readonly ITreatmentStageRepository _treatmentStageRepository;
        private readonly CloseTreatmentStageCommandHandler _handler;

        public CloseTreatmentStageCommandHandlerTests()
        {
            _fixture = new Fixture();
            _treatmentStageRepository = Substitute.For<ITreatmentStageRepository>();
            _handler = new CloseTreatmentStageCommandHandler(_treatmentStageRepository);
        }

        [Fact]
        public async Task Handle_ShouldReturnError_WhenTreatmentStageNotFound()
        {
            // Arrange
            var command = _fixture.Create<CloseTreatmentStageCommand>();

            _treatmentStageRepository.GetByIdAsync(Arg.Is<TreatmentStageId>(id => id == new TreatmentStageId(command.TreatmentStageId)))
                .Returns((TreatmentStage)null);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == TreatmentStageApplicationErrors.TratmentStageNotFound);
        }

        [Fact]
        public async Task Handle_ShouldReturnSuccess_WhenTreatmentStageClosedSuccessfully()
        {
            // Arrange
            var command = _fixture.Create<CloseTreatmentStageCommand>();
            var treatmentStage = CreateTreatmentTestData(new TreatmentTestDataOptions()).TreatmentStage;

            _treatmentStageRepository.GetByIdAsync(Arg.Is<TreatmentStageId>(id => id == new TreatmentStageId(command.TreatmentStageId)))
                .Returns(treatmentStage);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeTrue();
        }

        //[Fact]
        //public async Task Handle_ShouldReturnError_WhenClosingTreatmentStageFails()
        //{
        //    // Arrange
        //    var command = _fixture.Create<CloseTreatmentStageCommand>();
        //    var treatmentStage = CreateTreatmentTestData(new TreatmentTestDataOptions()).TreatmentStage;
        //    _treatmentStageRepository.GetByIdAsync(Arg.Is<TreatmentStageId>(id => id == new TreatmentStageId(command.TreatmentStageId)))
        //        .Returns(treatmentStage);

        //    // Act
        //    var result = await _handler.Handle(command, CancellationToken.None);

        //    // Assert
        //    result.IsFailed.Should().BeTrue();
        //}
    }
}
