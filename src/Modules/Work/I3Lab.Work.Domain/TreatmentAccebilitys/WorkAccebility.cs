using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.TreatmentStages;

namespace I3Lab.Treatments.Domain.WorkAccebilitys
{
    public class WorkAccebility : Entity, IAggregateRoot
    {
        public TreatmentStageId WorkId { get; private set; }
        public WorkAccebilityId Id { get; private set; }

        public readonly List<WorkAccebilityMember> WorkMembers = [];


        public WorkAccebility(TreatmentStageId workId)
        {
            Id = new WorkAccebilityId(Guid.NewGuid());
            WorkId = workId;   
        }

        public static WorkAccebility CreateNew(TreatmentStageId workId)
        {
            var newWorkAccebility = new WorkAccebility(workId);

            return newWorkAccebility;
        }

        public void JoinToWorkAccebility(MemberId memberId)
        {
            if (WorkMembers.Any(wm => wm.MemberId == memberId))
                throw new InvalidOperationException("MemberToInvite already joined.");

            var workMember = WorkAccebilityMember.CreateNew(Id, memberId);
            WorkMembers.Add(workMember);
        }

        public void LeaveWorkAccebility(MemberId memberId)
        {
            var member = WorkMembers.FirstOrDefault(wm => wm.MemberId == memberId);
            if (member == null)
                throw new InvalidOperationException("MemberToInvite not found.");

            member.Leave();
            WorkMembers.Remove(member);
        }
    }
}
