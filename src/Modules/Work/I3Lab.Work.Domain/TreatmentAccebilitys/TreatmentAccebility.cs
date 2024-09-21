using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.TreatmentStages;

namespace I3Lab.Treatments.Domain.WorkAccebilitys
{
    public class TreatmentAccebility : Entity, IAggregateRoot
    {
        public TreatmentStageId TreatmentStageId { get; private set; }
        public WorkAccebilityId Id { get; private set; }

        public readonly List<TreatmentAccebilityMember> TreatmentAccebilityMembers = [];


        public TreatmentAccebility(TreatmentStageId workId)
        {
            Id = new WorkAccebilityId(Guid.NewGuid());
            TreatmentStageId = workId;   
        }

        public static TreatmentAccebility CreateNew(TreatmentStageId workId)
        {
            var newWorkAccebility = new TreatmentAccebility(workId);

            return newWorkAccebility;
        }

        public void JoinToWorkAccebility(MemberId memberId)
        {
            if (TreatmentAccebilityMembers.Any(wm => wm.MemberId == memberId))
                throw new InvalidOperationException("MemberToInvite already joined.");

            var workMember = TreatmentAccebilityMember.CreateNew(Id, memberId);
            TreatmentAccebilityMembers.Add(workMember);
        }

        public void LeaveWorkAccebility(MemberId memberId)
        {
            var member = TreatmentAccebilityMembers.FirstOrDefault(wm => wm.MemberId == memberId);
            if (member == null)
                throw new InvalidOperationException("MemberToInvite not found.");

            member.Leave();
            TreatmentAccebilityMembers.Remove(member);
        }
    }
}
