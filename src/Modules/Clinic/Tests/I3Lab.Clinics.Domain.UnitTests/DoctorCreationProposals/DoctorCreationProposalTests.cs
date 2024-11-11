using FluentAssertions;
using I3Lab.Clinics.Domain.DoctorCreationProposals;
using I3Lab.Clinics.Domain.DoctorCreationProposals.Errors;
using I3Lab.Clinics.Domain.Doctors;

namespace I3Lab.Clinics.Domain.UnitTests.DoctorCreationProposals
{
    public class DoctorCreationProposalTests
    {
        private DoctorCreationProposal CreateProposal()
        {
            return DoctorCreationProposal.CreateNew(
                DoctorName.Create("John", "Doe"),
                Email.Create("john.doe@example.com"),
                PhoneNumber.Create("123-456-7890"),
                DoctorAvatar.Create("http://example.com/avatar.jpg"));
        }

        [Fact]
        public void CreateNew_ShouldInitializeWithValidationStatus()
        {
            var proposal = CreateProposal();

            proposal.ConfirmationStatus.Should().Be(ConfirmationStatus.Validation);
            proposal.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
        }

        [Fact]
        public void Confirm_ShouldChangeStatusToConfirmed_WhenStatusIsValidation()
        {
            var proposal = CreateProposal();

            var result = proposal.Confirm();

            result.IsSuccess.Should().BeTrue();
            proposal.ConfirmationStatus.Should().Be(ConfirmationStatus.Confirmed);
        }

        [Fact]
        public void Confirm_ShouldFail_WhenStatusIsNotValidation()
        {
            var proposal = CreateProposal();
            proposal.Confirm();

            var result = proposal.Confirm();

            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == DoctorCreationProposalsDomainErrors.ProposalCannotBeApproved);
        }

        [Fact]
        public void Reject_ShouldChangeStatusToRejected_WhenStatusIsValidation()
        {
            var proposal = CreateProposal();

            var result = proposal.Reject();

            result.IsSuccess.Should().BeTrue();
            proposal.ConfirmationStatus.Should().Be(ConfirmationStatus.Rejected);
        }

        [Fact]
        public void Reject_ShouldFail_WhenStatusIsNotValidation()
        {
            var proposal = CreateProposal();
            proposal.Reject();

            var result = proposal.Reject();

            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == DoctorCreationProposalsDomainErrors.ProposalCannotBeRejected);
        }
    }
}
