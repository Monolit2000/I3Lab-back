using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.Works;

namespace I3Lab.Works.Domain.WorkAccebilitys
{
    public class WorkAccebility : Entity, IAggregateRoot
    {
        public WorkId WorkId { get; private set; }
        public WorkAccebilityId Id { get; private set; }

        public readonly List<WorkAccebilityMember> WorkMembers = [];

        public WorkAccebility(WorkId workId)
        {
            Id = new WorkAccebilityId(Guid.NewGuid());
            WorkId = workId;   
        }

        public static WorkAccebility CreateNew(WorkId workId)
        {
            var newWorkAccebility = new WorkAccebility(workId);

            return newWorkAccebility;
        }

        public void JoinToWorkAccebility(MemberId memberId)
        {
            if (WorkMembers.Any(wm => wm.MemberId == memberId))
                throw new InvalidOperationException("Member already joined.");

            var workMember = WorkAccebilityMember.CreateNew(Id, memberId);
            WorkMembers.Add(workMember);
        }

        public void LeaveWorkAccebility(MemberId memberId)
        {
            var member = WorkMembers.FirstOrDefault(wm => wm.MemberId == memberId);
            if (member == null)
                throw new InvalidOperationException("Member not found.");

            member.Leave();
            WorkMembers.Remove(member);
        }
    }
}
