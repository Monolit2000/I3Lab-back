using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Domain.WorkAccebilitys.Events;
using System.Security.Cryptography.X509Certificates;

namespace I3Lab.Treatments.Domain.WorkAccebilitys
{
    public class TreatmentAccebilityMember : Entity
    {
        public WorkAccebilityId WorkAccebilityId { get; private set; }
        public MemberId MemberId { get; private set; }

        public AccessibilityType AccessibilityType { get; private set; }

        public DateTime JoinDate { get; private set; }

        public DateTime? LiveDate { get; private set; }

        private TreatmentAccebilityMember() { } //For Ef core 
        
        private TreatmentAccebilityMember(
            WorkAccebilityId workAccebilityId, 
            MemberId memberId)
        {
            WorkAccebilityId = workAccebilityId;
            MemberId = memberId;
            AccessibilityType = AccessibilityType.Edit;
            JoinDate = DateTime.Now;

            AddDomainEvent(new WorkAccebilityMemberAddedDomainEvent());
        }

        internal static TreatmentAccebilityMember CreateNew (
            WorkAccebilityId workAccebilityId, 
            MemberId memberId)
        {
            return new TreatmentAccebilityMember(
                workAccebilityId, 
                memberId);
        }

        public void Leave(string reason = "")
        {
            LiveDate = DateTime.UtcNow;
        }
    }
}
