using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments;

namespace I3Lab.Treatments.Domain.TreatmentInvites.Events
{
    public class TreatmentInviteAcceptedDomainEvent : DomainEventBase
    {
        public TreatmentId TreatmentId { get; }
        public MemberId InviterId { get; }
        public MemberId InviteeId { get; }

        public TreatmentInviteAcceptedDomainEvent(TreatmentId treatmentId, MemberId inviterId, MemberId inviteeId)
        {
            TreatmentId = treatmentId;
            InviterId = inviterId;
            InviteeId = inviteeId;
        }
    }
}
