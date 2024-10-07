

using I3Lab.BuildingBlocks.Domain;

namespace I3Lab.Treatments.Domain.TreatmentStages.Events
{
    public class TreatmentStageClosedDomainEvent : DomainEventBase
    {
        public TreatmentStageId TreatmentStageId { get; set; }

        public TreatmentStageClosedDomainEvent(TreatmentStageId treatmentStageId)
        {
            TreatmentStageId = treatmentStageId;
        }
    }
}
