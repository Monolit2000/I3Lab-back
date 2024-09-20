using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.Treatments;


namespace I3Lab.Treatments.Domain.TreatmentStages.Events
{
    public class WorkCreatedDomainEvent : DomainEventBase
    {
        public TreatmentStageId WorkId { get; }
        public TreatmentId TreatmentId { get; }

        public WorkCreatedDomainEvent(TreatmentStageId workId, TreatmentId treatmentId)
        {
            WorkId = workId;
            TreatmentId = treatmentId;  
        }
    }
}
