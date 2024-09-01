using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.Members;

namespace I3Lab.Works.Domain.Works.Events
{
    public class WorkMemberAddedDomainEvent : DomainEventBase
    {
        public WorkId WorkId { get; }
        public Member MemberId { get; }
        public Member AddedBy { get; }

        public WorkMemberAddedDomainEvent(
            WorkId workId,
            Member memberId,
            Member addedBy)
        {
            WorkId = workId;
            MemberId = memberId;
            AddedBy = addedBy;
        }
    }
}
