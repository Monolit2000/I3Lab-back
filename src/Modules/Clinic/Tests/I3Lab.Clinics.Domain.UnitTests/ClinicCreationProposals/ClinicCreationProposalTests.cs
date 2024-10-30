using FluentAssertions;
using I3Lab.Clinics.Domain.Clinics;
using I3Lab.Clinics.Domain.ClinicCreationProposals;
using I3Lab.Clinics.Domain.ClinicCreationProposals.Events;


namespace I3Lab.Clinics.Domain.UnitTests.ClinicCreationProposals
{
    public class ClinicCreationProposalTests
    {
        private ClinicCreationProposal CreateProposal()
        {
            return ClinicCreationProposal.CreateNew(
                ClinicName.Create("Downtown Clinic"),
                ClinicAddress.Create("123 Main St"));
        }

        [Fact]
        public void CreateNew_ShouldInitializeProposalWithGivenProperties()
        {
            // Act
            var proposal = CreateProposal();

            // Assert
            proposal.ClinicName.Value.Should().Be("Downtown Clinic");
            proposal.Address.Value.Should().Be("123 Main St");
            proposal.ConfirmationStatus.Should().Be(ConfirmationStatus.Validation);
            proposal.DomainEvents.Should().ContainSingle(e => e is ClinicCreationProposalCreatedDomainEvent);
        }

        [Fact]
        public void Confirm_ShouldSetStatusToConfirmedAndAddDomainEvent()
        {
            // Arrange
            var proposal = CreateProposal();

            // Act
            proposal.Confirm();

            // Assert
            proposal.ConfirmationStatus.Should().Be(ConfirmationStatus.Confirmed);
            proposal.DomainEvents.Should().ContainSingle(e => e is ClinicCreationProposalConfirmedDomainEvent);
        }

        [Fact]
        public void Confirm_ShouldThrowException_WhenStatusIsNotValidation()
        {
            // Arrange
            var proposal = CreateProposal();
            proposal.Confirm(); // First confirm to change the status

            // Act
            Action act = () => proposal.Confirm();

            // Assert
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Proposal cannot be confirmed.");
        }

        [Fact]
        public void Reject_ShouldSetStatusToRejectedAndAddDomainEvent()
        {
            // Arrange
            var proposal = CreateProposal();

            // Act
            proposal.Reject();

            // Assert
            proposal.ConfirmationStatus.Should().Be(ConfirmationStatus.Rejected);
            proposal.DomainEvents.Should().ContainSingle(e => e is ClinicCreationProposalRejectedDomainEvent);
        }

        [Fact]
        public void Reject_ShouldThrowException_WhenStatusIsNotValidation()
        {
            // Arrange
            var proposal = CreateProposal();
            proposal.Reject(); // First reject to change the status

            // Act
            Action act = () => proposal.Reject();

            // Assert
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Proposal cannot be rejected.");
        }

        [Fact]
        public void CreateClinic_ShouldReturnClinicWithSameNameAndAddress()
        {
            // Arrange
            var proposal = CreateProposal();

            // Act
            var clinic = proposal.CreateClinic();

            // Assert
            clinic.ClinicName.Value.Should().Be(proposal.ClinicName.Value);
            clinic.Address.Value.Should().Be(proposal.Address.Value);
        }
    }
}
