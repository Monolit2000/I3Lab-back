using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.Members;

namespace I3Lab.Treatments.Domain.Treatments.Events
{
    public class TreatmentMemberAddedDomainEvent : DomainEventBase
    {
        public TreatmentId TreatmentId { get; }
        public MemberId MemberId { get; }

        public TreatmentMemberAddedDomainEvent(TreatmentId treatmentId, MemberId memberId)
        {
            TreatmentId = treatmentId;
            MemberId = memberId;
        }
    }
}
