using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.Treatments;


namespace I3Lab.Works.Domain.Works.Events
{
    public class WorkCreatedDomainEvent : DomainEventBase
    {
        public WorkId WorkId { get; }
        public TreatmentId TreatmentId { get; }

        public WorkCreatedDomainEvent(WorkId workId, TreatmentId treatmentId)
        {
            WorkId = workId;
            TreatmentId = treatmentId;  
        }
    }
}
