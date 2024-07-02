using I3Lab.BuildingBlocks.Domain;
using I3Lab.Work.Domain.Work;


namespace I3Lab.Work.Domain.Works.Events
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
