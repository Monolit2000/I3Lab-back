using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.Treatments;


namespace I3Lab.Treatments.Domain.TreatmentStages.Events
{
    public class WorkCreatedDomainEvent : DomainEventBase
    {
        public TreatmentStageId TreatmentStageId { get; }
        public TreatmentId TreatmentId { get; }

        public WorkCreatedDomainEvent(TreatmentStageId workId, TreatmentId treatmentId)
        {
            TreatmentStageId = workId;
            TreatmentId = treatmentId;  
        }
    }
}
