using I3Lab.BuildingBlocks.Domain;


namespace I3Lab.Works.Domain.Works.Events
{
    public class WorkCreatedDomainEvent : DomainEventBase
    {
        public WorkId WorkId { get; }

        public WorkCreatedDomainEvent(WorkId workId)
        {
            WorkId = workId;
        }
    }
}
