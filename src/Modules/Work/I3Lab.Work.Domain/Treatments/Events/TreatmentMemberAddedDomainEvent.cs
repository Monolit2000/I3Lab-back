using I3Lab.BuildingBlocks.Domain;

namespace I3Lab.Works.Domain.Treatments.Events
{
    public class TreatmentMemberAddedDomainEvent : DomainEventBase
    {
        public Guid TreatmentId { get; }
        public Guid MemberId { get; }

        public TreatmentMemberAddedDomainEvent(Guid treatmentId, Guid memberId)
        {
            TreatmentId = treatmentId;
            MemberId = memberId;
        }
    }
}
