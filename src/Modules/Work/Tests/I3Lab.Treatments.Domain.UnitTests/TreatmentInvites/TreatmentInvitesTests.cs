using FluentAssertions;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.TreatmentInvites;
using I3Lab.Treatments.Domain.TreatmentInvites.Events;
using I3Lab.Treatments.Domain.Treatments;


namespace I3Lab.Treatments.Domain.UnitTests.TreatmentInvites
{
    public class TreatmentInviteTests
    {

        private readonly Treatment Treatment = Treatment.CreateNew(
            Member.Create(new MemberId(Guid.NewGuid()), "testEmail@gmail.com"),
            Member.Create(new MemberId(Guid.NewGuid()), "testEmail@gmail.com"), 
            TreatmentTitel.Create("Initial Treatment"));

        [Fact]
        public void InviteBasedOnTreatment_Should_CreateNewInvite_WithPendingStatus()
        {
            // Arrange
            var treatment = Treatment;
            var invitedMember = Member.Create(new MemberId(Guid.NewGuid()), "invited@example.com");
            var inviterMember = Member.Create(new MemberId(Guid.NewGuid()), "inviter@example.com");

            // Act
            var result = TreatmentInvite.InviteBasedOnTreatment(treatment, invitedMember, inviterMember);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.TreatmentInviteStatus.Should().Be(TreatmentInviteStatus.Pending);
            result.Value.InvitedMember.Should().Be(invitedMember);
            result.Value.InviterMember.Should().Be(inviterMember);
            result.Value.DomainEvents.Should().ContainSingle(e => e is TreatmentInviteCreatedDomainEvent);
        }

        [Fact]
        public void Accept_Should_ChangeStatusToAccepted_AndAddDomainEvent_WhenStatusIsPending()
        {
            // Arrange
            var invite = CreateSampleInvite();

            // Act
            var result = invite.Accept();

            // Assert
            result.IsSuccess.Should().BeTrue();
            invite.TreatmentInviteStatus.Should().Be(TreatmentInviteStatus.Accepted);
            invite.DomainEvents.Should().ContainSingle(e => e is TreatmentInviteAcceptedDomainEvent);
        }

        [Fact]
        public void Reject_Should_ChangeStatusToRejected_AndAddDomainEvent_WhenStatusIsPending()
        {
            // Arrange
            var invite = CreateSampleInvite();

            // Act
            var result = invite.Reject();

            // Assert
            result.IsSuccess.Should().BeTrue();
            invite.TreatmentInviteStatus.Should().Be(TreatmentInviteStatus.Rejected);
            invite.DomainEvents.Should().ContainSingle(e => e is TreatmentInviteRejectedDomainEvent);
        }

        [Fact]
        public void Accept_Should_Fail_WhenStatusIsNotPending()
        {
            // Arrange
            var invite = CreateSampleInvite();
            invite.Accept(); // Set status to Accepted

            // Act
            var result = invite.Accept();

            // Assert
            result.IsFailed.Should().BeTrue();
            invite.TreatmentInviteStatus.Should().Be(TreatmentInviteStatus.Accepted);
        }

        [Fact]
        public void Reject_Should_Fail_WhenStatusIsNotPending()
        {
            // Arrange
            var invite = CreateSampleInvite();
            invite.Reject(); // Set status to Rejected

            // Act
            var result = invite.Reject();

            // Assert
            result.IsFailed.Should().BeTrue();
            invite.TreatmentInviteStatus.Should().Be(TreatmentInviteStatus.Rejected);
        }


        [Fact]
        public void GenerateInviteLink_Should_ReturnInviteLink_WhenTokenIsValid()
        {
            // Arrange
            var invite = CreateSampleInvite();

            string testLink = "/join-invite?token=";

            // Act
            var inviteLink = invite.GenerateInviteLink(testLink);

            // Assert
            inviteLink.Should().Contain(testLink);
            invite.InviteToken.Should().NotBeNull();
            invite.InviteToken.IsExpired().Should().BeFalse();
        }

        [Fact]
        public void ValidateInviteToken_Should_ReturnSuccess_WhenTokenIsValid()
        {
            // Arrange
            var invite = CreateSampleInvite();
            var token = invite.InviteToken.Token;

            // Act
            var result = invite.ValidateInviteToken(token);

            // Assert
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void ValidateInviteToken_Should_Fail_WhenTokenIsInvalid()
        {
            // Arrange
            var invite = CreateSampleInvite();

            // Act
            var result = invite.ValidateInviteToken("invalid_token");

            // Assert
            result.IsFailed.Should().BeTrue();
        }

        private TreatmentInvite CreateSampleInvite()
        {
            var treatment = Treatment;
            var invitedMember = Member.Create(new MemberId(Guid.NewGuid()), "invited@example.com");
            var inviterMember = Member.Create(new MemberId(Guid.NewGuid()), "inviter@example.com");

            return TreatmentInvite.InviteBasedOnTreatment(treatment, invitedMember, inviterMember).Value;
        }


        //[Fact]
        //public void GenerateInviteToken_Should_CreateNewToken_WhenNoActiveTokenExists()
        //{
        //    // Arrange
        //    var invite = CreateSampleInvite();

        //    // Act
        //    var result = invite.GenerateInviteToken(TimeSpan.FromHours(24));

        //    // Assert
        //    result.IsSuccess.Should().BeTrue();
        //    invite.InviteToken.Should().NotBeNull();
        //    invite.InviteToken.IsExpired().Should().BeFalse();
        //}

        //[Fact]
        //public void GenerateInviteToken_Should_Fail_WhenActiveTokenExists()
        //{
        //    // Arrange
        //    var invite = CreateSampleInvite();

        //    // Act
        //    var result = invite.GenerateInviteToken(TimeSpan.FromHours(24));

        //    // Assert
        //    result.IsFailed.Should().BeTrue();
        //}
    }
}
