using I3Lab.BuildingBlocks.Domain;

namespace I3Lab.Treatments.Domain.TreatmentStages.Events
{
    public class WorkStatusChangedDomainEvent : DomainEventBase
    {
        public TreatmentStageId WorkId{ get; }
        public TreatmentStageStatus NewStatus { get; }

        public WorkStatusChangedDomainEvent(TreatmentStageId workId, TreatmentStageStatus newStatus)
        {
            WorkId = workId;
            NewStatus = newStatus;
        }
    }
}
