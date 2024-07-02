using I3Lab.BuildingBlocks.Domain;
using I3Lab.Work.Domain.Members;
using I3Lab.Work.Domain.Works.Events;


namespace I3Lab.Work.Domain.Works
{
    public class WorkMember : Entity
    {
        public WorkId WorkId { get; private set; }
        public MemberId MemberId { get; private set; }
        public MemberAccessibilityType AccessibilityType { get; private set; }

        public DateTime JoinDate { get; private set; }

        private WorkMember()
        {
        }

        private WorkMember(WorkId workId, MemberId memberId) 
        {
            WorkId = workId;
            MemberId = memberId;
            JoinDate = DateTime.UtcNow;
        }

        public static WorkMember CreateNew(WorkId workId, MemberId memberId)
        {
            return new WorkMember(workId, memberId);
        }

        public void ChangeAccessibilityType()
        {
            AddDomainEvent(new MemberAccessibilityTypeChengedDomainEvent());
        }

    }
}
