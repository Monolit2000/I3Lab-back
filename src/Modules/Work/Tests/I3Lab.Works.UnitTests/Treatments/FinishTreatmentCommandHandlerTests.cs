using AutoFixture;
using FluentAssertions;
using FluentResults;
using I3Lab.Treatments.Application.Treatments.FinishTreatment;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Application.Treatments.ApplicationErrors;
using NSubstitute;
using Xunit;
using System.Threading;
using System.Threading.Tasks;
using I3Lab.Treatments.Domain.Members;

namespace I3Lab.Treatments.UnitTests.Treatments
{

    public class FinishTreatmentCommandHandlerTests : TreatmentTestsBase
    {
        private readonly Fixture _fixture;
        private readonly ITreatmentRepository _treatmentRepository;
        private readonly FinishTreatmentCommandHandler _handler;

        public FinishTreatmentCommandHandlerTests()
        {
            _fixture = new Fixture();
            _treatmentRepository = Substitute.For<ITreatmentRepository>();
            _handler = new FinishTreatmentCommandHandler(_treatmentRepository);
        }

        [Fact]
        public async Task Handle_ShouldReturnError_WhenTreatmentNotFound()
        {
            // Arrange
            var command = _fixture.Create<FinishTreatmentCommand>();

            _treatmentRepository.GetByIdAsync(Arg.Is<TreatmentId>(id => id == new TreatmentId(command.TreatmentId)))
                .Returns((Treatment)null);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == TreatmentsErrors.TreatmentNotFound);
        }

        [Fact]
        public async Task Handle_ShouldReturnError_WhenFinishFails()
        {
            // Arrange
            var command = _fixture.Create<FinishTreatmentCommand>();
            var treatment = CreateTretmentTestData();

            treatment.Cancel();

            _treatmentRepository.GetByIdAsync(Arg.Is<TreatmentId>(id => id == new TreatmentId(command.TreatmentId)))
                .Returns(treatment);



            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
        }

        [Fact]
        public async Task Handle_ShouldFinishTreatmentSuccessfully()
        {
            // Arrange
            var command = _fixture.Create<FinishTreatmentCommand>();
            var treatment = CreateTretmentTestData();

            _treatmentRepository.GetByIdAsync(Arg.Is<TreatmentId>(id => id == new TreatmentId(command.TreatmentId)))
                .Returns(treatment);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeTrue();
            await _treatmentRepository.Received(1).SaveChangesAsync(Arg.Any<CancellationToken>());
        }


        private Treatment CreateTretmentTestData()
        {
            var treatment = Treatment.CreateNew(
              _fixture.Create<Member>(),
              _fixture.Create<Member>(),
              TreatmentTitel.Create("Sample Treatment"));

            return treatment;
        }
    }
}