using I3Lab.Work.Domain.Members;

namespace I3Lab.Work.Domain.WorkAccebilitys
{
    public class WorkAccebilityMember
    {
        public WorkAccebilityId WorkAccebilityId { get; private set; }
        public MemberId MemberId { get; private set; }

        private WorkAccebilityMember() { } //For Ef core 
        
        private WorkAccebilityMember(
            WorkAccebilityId workAccebilityId, 
            MemberId memberId)
        {
            WorkAccebilityId = workAccebilityId;
            MemberId = memberId;
        }

        internal static WorkAccebilityMember CreateNew (
            WorkAccebilityId workAccebilityId, 
            MemberId memberId)
        {
            return new WorkAccebilityMember(
                workAccebilityId, 
                memberId);
        }
    }
}
