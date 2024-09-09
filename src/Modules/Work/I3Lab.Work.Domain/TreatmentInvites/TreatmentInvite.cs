using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.Treatments;
using FluentResults;
using I3Lab.Works.Domain.TreatmentInvites.Events;

namespace I3Lab.Works.Domain.TreatmentInvites
{
    public class TreatmentInvite : Entity, IAggregateRoot
    {
        public Member MemberToInvite { get; private set; }
        public Member Inviter { get; private set; }
        public Treatment Treatment { get; private set; }

        public TreatmentInviteId Id { get; private set; }
        public TreatmentInviteStatus TreatmentInviteStatus { get; private set; }
        public DateTime OcurredOn { get; private set; } 

        private TreatmentInvite() { } // For EF core only

        private TreatmentInvite(Treatment treatment, Member memberToInvite, Member inviter)
        {
            Id = new TreatmentInviteId(Guid.NewGuid());
            Treatment = treatment;
            MemberToInvite = memberToInvite;
            Inviter = inviter;
            OcurredOn = DateTime.UtcNow;
            TreatmentInviteStatus = TreatmentInviteStatus.Pending;

            AddDomainEvent(new TreatmentInviteCreatedDomainEvent(
                this.Treatment, 
                this.MemberToInvite,
                this.Inviter));
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

        public void Accept()
        {
            if (TreatmentInviteStatus != TreatmentInviteStatus.Pending)
                throw new InvalidOperationException("Only pending invites can be accepted.");

            TreatmentInviteStatus = TreatmentInviteStatus.Accepted;
            AddDomainEvent(new TreatmentInviteAcceptedDomainEvent());
        }

        public void Reject()
        {
            if (TreatmentInviteStatus != TreatmentInviteStatus.Pending)
                throw new InvalidOperationException("Only pending invites can be declined.");

            TreatmentInviteStatus = TreatmentInviteStatus.Rejected;

            AddDomainEvent(new TreatmentInviteRejectedDomainEvent());
        }
    }

   
}
