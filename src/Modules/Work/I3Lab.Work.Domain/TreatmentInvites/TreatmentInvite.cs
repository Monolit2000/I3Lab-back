using FluentResults;
using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Domain.TreatmentInvites.Rule;
using I3Lab.Treatments.Domain.TreatmentInvites.Events;

namespace I3Lab.Treatments.Domain.TreatmentInvites
{
    public class TreatmentInvite : Entity, IAggregateRoot
    {
        public Treatment Treatment { get; private set; }
        public Member InvitedMember { get; private set; }
        public Member InviterMember { get; private set; }

        public TreatmentInviteId Id { get; private set; }
        public TreatmentInviteStatus TreatmentInviteStatus { get; private set; }
        public InviteToken InviteToken { get; private set; }
        public DateTime OcurredOn { get; private set; } 

        private TreatmentInvite() { } // For EF core only

        private TreatmentInvite(Treatment treatment, Member memberToInvite, Member inviter)
        {
            Id = new TreatmentInviteId(Guid.NewGuid());
            Treatment = treatment;
            InvitedMember = memberToInvite;
            InviterMember = inviter;
            OcurredOn = DateTime.UtcNow;
            TreatmentInviteStatus = TreatmentInviteStatus.Pending;

            InviteToken = InviteToken.Generate(TimeSpan.FromHours(24));

            AddDomainEvent(new TreatmentInviteCreatedDomainEvent(
                this.Treatment, 
                this.InvitedMember,
                this.InviterMember));
        }

        public static Result<TreatmentInvite> InviteBasedOnTreatment(
            Treatment treatment,
            Member memberToInvite, 
            Member inviter)
        {
            return new TreatmentInvite(
                treatment, 
                memberToInvite, 
                inviter);
        }

        public Result Accept()
        {
            var result = CheckRule(new TreatmentInviteStatusMustByPending(TreatmentInviteStatus));
            if (result.IsFailed)
                return result;

            TreatmentInviteStatus = TreatmentInviteStatus.Accepted;
            AddDomainEvent(new TreatmentInviteAcceptedDomainEvent(Treatment.Id, InvitedMember.Id, InviterMember.Id));
            return Result.Ok();
        }

        public Result Reject()
        {
            var result = CheckRule(new TreatmentInviteStatusMustByPending(TreatmentInviteStatus));
            if (result.IsFailed)
                return result;

            TreatmentInviteStatus = TreatmentInviteStatus.Rejected;
            AddDomainEvent(new TreatmentInviteRejectedDomainEvent());
            return Result.Ok();
        }

        //public Result GenerateInviteToken(TimeSpan tokenLifetime)
        //{
        //    if (InviteToken != null && !InviteToken.IsExpired())
        //        return Result.Fail("An active invite link already exists.");

        //    InviteToken = InviteToken.Generate(tokenLifetime);
        //    return Result.Ok();
        //}

        public string GenerateInviteLink(string link)
        {
            if (InviteToken == null || InviteToken.IsExpired())
                InviteToken = InviteToken.Generate(TimeSpan.FromHours(24));

            //var inviteLink = $"/join-invite?token={InviteToken.Token}";
            var inviteLink = $"{link}={InviteToken.Token}";

            return inviteLink;
        }
        public Result ValidateInviteToken(string token)
        {
            if (InviteToken == null)
                return Result.Fail("No invite token exists.");

            return InviteToken.Validate(token);
        }
    }
}
