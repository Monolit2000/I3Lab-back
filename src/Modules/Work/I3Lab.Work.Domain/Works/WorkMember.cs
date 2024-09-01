using FluentResults;
using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.Works.Events;


namespace I3Lab.Works.Domain.Works
{
    public class WorkMember : Entity
    {
        public WorkId WorkId { get; private set; }
        public Member Member { get; private set; }
        public MemberAccessibilityType AccessibilityType { get; private set; }

        public Member AddedBy { get; private set; }
        public DateTime JoinDate { get; private set; }

        private WorkMember() { } //for EF core

        private WorkMember(
            WorkId workId,
            Member member,
            Member addedBy) 
        {
            WorkId = workId;
            Member = member;
            AddedBy = addedBy;
            JoinDate = DateTime.UtcNow;
        }

        public static WorkMember CreateNew(
            WorkId workId,
            Member memberId,
            Member addedBy)
        {
            return new WorkMember(
                workId, 
                memberId,
                addedBy);
        }


        public Result ChangeAccessibilityType(MemberAccessibilityType newAccessibilityType)
        {
            if (AccessibilityType == newAccessibilityType)
                return Result.Ok();

            AccessibilityType = newAccessibilityType;

            AddDomainEvent(new MemberAccessibilityTypeChangedDomainEvent(
                WorkId, 
                Member, 
                newAccessibilityType));

            return Result.Ok();
        }

    }
}
