using I3Lab.BuildingBlocks.Domain;


namespace I3Lab.Works.Domain.Works.Events
{
    public class WorkAvatarImageSetDomainEvent : DomainEventBase
    {
        public WorkFile WorkFile { get; }

        public WorkAvatarImageSetDomainEvent(WorkFile workFile)
        {
            WorkFile = workFile;
        }
    }
}
