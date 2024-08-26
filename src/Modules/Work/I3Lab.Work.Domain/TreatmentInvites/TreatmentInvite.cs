using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.Treatments;
using FluentResults;

namespace I3Lab.Works.Domain.TreatmentInvites
{
    public class TreatmentInvite : Entity, IAggregateRoot
    {
        public TreatmentInviteId Id { get; private set; }
        public Member Member { get; private set; }
        public Treatment Treatment { get; private set; }
        public TreatmentInviteStatus TreatmentInviteStatus { get; private set; }

        public DateTime OcurredOn { get; private set; } 

        private TreatmentInvite() { }

        private TreatmentInvite(Treatment treatment, Member member)
        {
            Id = new TreatmentInviteId(Guid.NewGuid());
            Treatment = treatment;
            Member = member;
            OcurredOn = DateTime.UtcNow;
            TreatmentInviteStatus = TreatmentInviteStatus.Pending;
        }

        public static Result<TreatmentInvite> InviteBasedOnTreatment(
            Treatment treatment,
            Member member
            )
        {
            var invite = new TreatmentInvite(treatment, member);
            return Result.Ok(invite);
        }

        public void Accept()
        {
            if (TreatmentInviteStatus != TreatmentInviteStatus.Pending)
                throw new InvalidOperationException("Only pending invites can be accepted.");

            TreatmentInviteStatus = TreatmentInviteStatus.Accepted;
        }

        public void Reject()
        {
            if (TreatmentInviteStatus != TreatmentInviteStatus.Pending)
                throw new InvalidOperationException("Only pending invites can be declined.");

            TreatmentInviteStatus = TreatmentInviteStatus.Rejected;
        }
    }

   
}
