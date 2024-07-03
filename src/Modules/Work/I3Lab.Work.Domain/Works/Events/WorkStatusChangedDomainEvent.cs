using I3Lab.BuildingBlocks.Domain;

namespace I3Lab.Works.Domain.Works.Events
{
    public class WorkStatusChangedDomainEvent : DomainEventBase
    {
        public WorkId WorkId{ get; }
        public WorkStatus NewStatus { get; }

        public WorkStatusChangedDomainEvent(WorkId workId, WorkStatus newStatus)
        {
            WorkId = workId;
            NewStatus = newStatus;
        }
    }
}
