using AutoFixture;
using FluentAssertions;
using I3Lab.Treatments.Application.Treatments.ApplicationErrors;
using I3Lab.Treatments.Application.Treatments.CancelTreatment;
using I3Lab.Treatments.Domain.Treatments;
using NSubstitute;


namespace I3Lab.Treatments.UnitTests.Treatments
{
    public class CancelTreatmentCommandHandlerTests : TreatmentTestsBase
    {
        private readonly Fixture _fixture;
        private readonly ITreatmentRepository _treatmentRepository;
        private readonly CancelTreatmentCommandHandler _handler;

        public CancelTreatmentCommandHandlerTests()
        {
            _fixture = new Fixture();
            _treatmentRepository = Substitute.For<ITreatmentRepository>();

            _handler = new CancelTreatmentCommandHandler(_treatmentRepository);
        }

        [Fact]
        public async Task Handle_ShouldCancelTreatmentSuccessfully_WhenTreatmentExists()
        {
            // Arrange
            var command = _fixture.Create<CancelTreatmentCommand>();
            var treatment = CreateTreatmentTestData(new TreatmentTestDataOptions()).Treatment;

            _treatmentRepository.GetByIdAsync(Arg.Is<TreatmentId>(id => id == new TreatmentId(command.TreatmentId)))
                .Returns(treatment);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeTrue();
            await _treatmentRepository.Received(1).SaveChangesAsync(CancellationToken.None);
        }

        [Fact]
        public async Task Handle_ShouldReturnError_WhenTreatmentNotFound()
        {
            // Arrange
            var command = _fixture.Create<CancelTreatmentCommand>();

            _treatmentRepository.GetByIdAsync(Arg.Any<TreatmentId>())
                .Returns((Treatment)null);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == TreatmentsErrors.TreatmentNotFound);
            await _treatmentRepository.DidNotReceive().SaveChangesAsync(Arg.Any<CancellationToken>());
        }

        [Fact]
        public async Task Handle_ShouldReturnError_WhenCancellationFails()
        {
            // Arrange
            var command = _fixture.Create<CancelTreatmentCommand>();
            var treatment = CreateTreatmentTestData(new TreatmentTestDataOptions()).Treatment;

            treatment.Cancel();

            _treatmentRepository.GetByIdAsync(Arg.Is<TreatmentId>(id => id == new TreatmentId(command.TreatmentId)))
                .Returns(treatment);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
            await _treatmentRepository.DidNotReceive().SaveChangesAsync(Arg.Any<CancellationToken>());
        }
    }
}
