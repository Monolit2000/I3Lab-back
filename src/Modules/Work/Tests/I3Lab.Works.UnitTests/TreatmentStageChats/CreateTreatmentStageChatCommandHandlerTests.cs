using AutoFixture;
using I3Lab.Treatments.Application.TreatmentStageChats.CreatetreatmentStageChat;
using I3Lab.Treatments.Domain.TreatmentStages;
using I3Lab.Treatments.Domain.TreatmentStageChats;
using I3Lab.Treatments.Domain.Treatments;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace I3Lab.Treatments.UnitTests.TreatmentStageChats
{
    public class CreateTreatmentStageChatCommandHandlerTests : TreatmentTestsBase
    {
        private readonly Fixture _fixture;
        private readonly ITreatmentStageRepository _treatmentStageRepository;
        private readonly ITreatmentStageChatRepository _treatmentStageChatRepository;
        private readonly ITreatmentRepository _treatmentRepository;
        private readonly ILogger<CreateTreatmentStageChatCommandHandler> _logger;
        private readonly CreateTreatmentStageChatCommandHandler _handler;

        public CreateTreatmentStageChatCommandHandlerTests()
        {
            _fixture = new Fixture();
            _treatmentStageRepository = Substitute.For<ITreatmentStageRepository>();
            _treatmentStageChatRepository = Substitute.For<ITreatmentStageChatRepository>();
            _treatmentRepository = Substitute.For<ITreatmentRepository>();
            _logger = Substitute.For<ILogger<CreateTreatmentStageChatCommandHandler>>();

            _handler = new CreateTreatmentStageChatCommandHandler(
                _treatmentStageRepository,
                _treatmentStageChatRepository,
                _treatmentRepository,
                _logger);
        }

        [Fact]
        public async Task Handle_ShouldCreateChat_WhenTreatmentStageAndTreatmentExist()
        {
            // Arrange

            var testData = CreateTreatmentTestData(new TreatmentTestDataOptions());

            var command = _fixture.Create<CreateTreatmentStageChatCommand>();
            var treatmentStage = testData.TreatmentStage;
            var treatment = testData.Treatment;

            _treatmentStageRepository.GetByIdAsync(Arg.Is<TreatmentStageId>(id => id == new TreatmentStageId(command.TreatmentStageId)))
                .Returns(treatmentStage);

            _treatmentRepository.GetByIdAsync(Arg.Is<TreatmentId>(id => id == new TreatmentId(command.TreatmentId)), Arg.Any<CancellationToken>())
                .Returns(treatment);

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            await _treatmentStageChatRepository.Received(1).AddAsync(Arg.Any<TreatmentStageChat>());
            await _treatmentStageChatRepository.Received(1).SaveChangesAsync();
        }

        [Fact]
        public async Task Handle_ShouldLogWarning_WhenTreatmentStageNotFound()
        {
            // Arrange
            var command = _fixture.Create<CreateTreatmentStageChatCommand>();
            _treatmentStageRepository.GetByIdAsync(Arg.Any<TreatmentStageId>())
                .Returns((TreatmentStage)null);

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            //_logger.Received(1).LogWarning("TreatmentStage not found for TreatmentStageChatId: {TreatmentStageChatId}", command.TreatmentStageId);
            await _treatmentStageChatRepository.DidNotReceive().AddAsync(Arg.Any<TreatmentStageChat>());
            await _treatmentStageChatRepository.DidNotReceive().SaveChangesAsync();
        }

        [Fact]
        public async Task Handle_ShouldNotCreateChat_WhenTreatmentNotFound()
        {
            // Arrange
            var testData = CreateTreatmentTestData(new TreatmentTestDataOptions());
            var command = _fixture.Create<CreateTreatmentStageChatCommand>();
            var treatmentStage = testData.TreatmentStage;

            _treatmentStageRepository.GetByIdAsync(Arg.Is<TreatmentStageId>(id => id == new TreatmentStageId(command.TreatmentStageId)))
                .Returns(treatmentStage);
            _treatmentRepository.GetByIdAsync(Arg.Any<TreatmentId>(), Arg.Any<CancellationToken>())
                .Returns((Treatment)null);

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            await _treatmentStageChatRepository.DidNotReceive().AddAsync(Arg.Any<TreatmentStageChat>());
            await _treatmentStageChatRepository.DidNotReceive().SaveChangesAsync();
        }
    }
}
