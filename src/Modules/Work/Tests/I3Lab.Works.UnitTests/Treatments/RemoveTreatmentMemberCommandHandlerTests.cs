using AutoFixture;
using FluentAssertions;
using I3Lab.Treatments.Application.Treatments.ApplicationErrors;
using I3Lab.Treatments.Application.Treatments.RemoveTreatmentMember;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Domain.Treatments.Errors;
using NSubstitute;

namespace I3Lab.Treatments.UnitTests.Treatments
{
    public class RemoveTreatmentMemberCommandHandlerTests : TreatmentTestsBase
    {
        private readonly Fixture _fixture;
        private readonly ITreatmentRepository _treatmentRepository;
        private readonly RemoveTreatmentMemberCommandHandler _handler;

        public RemoveTreatmentMemberCommandHandlerTests()
        {
            _fixture = new Fixture();
            _treatmentRepository = Substitute.For<ITreatmentRepository>();
            _handler = new RemoveTreatmentMemberCommandHandler(_treatmentRepository);
        }

        [Fact]
        public async Task Handle_ShouldReturnError_WhenTreatmentNotFound()
        {
            // Arrange
            var command = _fixture.Create<RemoveTreatmentMemberCommand>();

            _treatmentRepository.GetByIdAsync(Arg.Is<TreatmentId>(id => id == new TreatmentId(command.TreatmentId)), Arg.Any<CancellationToken>())
                .Returns((Treatment)null);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == TreatmentsErrors.TreatmentNotFound);
        }

        [Fact]
        public async Task Handle_ShouldReturnError_WhenMemberNotFound()
        {
            // Arrange
            var command = _fixture.Create<RemoveTreatmentMemberCommand>();
            var treatment = CreateTretmentTestData();
            var unAddedMember = _fixture.Create<Member>();

            _treatmentRepository.GetByIdAsync(Arg.Is<TreatmentId>(id => id == new TreatmentId(command.TreatmentId)), Arg.Any<CancellationToken>())
                .Returns(treatment);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == TreatmentErrors.MemberNotFound);
        }

        [Fact]
        public async Task Handle_ShouldRemoveTreatmentMemberSuccessfully()
        {
            // Arrange
            var treatment = CreateTretmentTestData();

            var command = new RemoveTreatmentMemberCommand(
                Guid.NewGuid(),
                treatment.Creator.Id.Value,
                treatment.Patient.Id.Value);

            _treatmentRepository.GetByIdAsync(Arg.Is<TreatmentId>(id => id == new TreatmentId(command.TreatmentId)), Arg.Any<CancellationToken>())
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