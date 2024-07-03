using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.Works.Events;


namespace I3Lab.Works.Domain.Works
{
    public class WorkMember : Entity
    {
        public WorkId WorkId { get; private set; }
        public MemberId MemberId { get; private set; }
        public MemberAccessibilityType AccessibilityType { get; private set; }
        public MemberId AddedBy { get; private set; }
        public DateTime JoinDate { get; private set; }

        private WorkMember()
        {
        }

        private WorkMember(WorkId workId, MemberId memberId, MemberId addedBy) 
        {
            WorkId = workId;
            MemberId = memberId;
            AddedBy = addedBy;
            JoinDate = DateTime.UtcNow;
        }

        public static WorkMember CreateNew(
            WorkId workId, 
            MemberId memberId, 
            MemberId addedBy)
        {
            return new WorkMember(
                workId, 
                memberId,
                addedBy);
        }

        public void ChangeAccessibilityType()
        {
            AddDomainEvent(new MemberAccessibilityTypeChengedDomainEvent());
        }

    }
}
