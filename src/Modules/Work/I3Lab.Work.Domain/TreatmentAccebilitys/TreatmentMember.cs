﻿using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Domain.WorkAccebilitys.Events;
using System.Security.Cryptography.X509Certificates;

namespace I3Lab.Treatments.Domain.WorkAccebilitys
{
    public class TreatmentMember : Entity
    {
        public WorkAccebilityId WorkAccebilityId { get; private set; }
        public MemberId MemberId { get; private set; }

        public AccessibilityType AccessibilityType { get; private set; }

        public DateTime JoinDate { get; private set; }

        public DateTime? LiveDate { get; private set; }

        private TreatmentMember() { } //For Ef core 
        
        private TreatmentMember(
            WorkAccebilityId workAccebilityId, 
            MemberId memberId)
        {
            WorkAccebilityId = workAccebilityId;
            MemberId = memberId;
            AccessibilityType = AccessibilityType.Edit;
            JoinDate = DateTime.Now;

            AddDomainEvent(new WorkAccebilityMemberAddedDomainEvent());
        }

        internal static TreatmentMember CreateNew (
            WorkAccebilityId workAccebilityId, 
            MemberId memberId)
        {
            return new TreatmentMember(
                workAccebilityId, 
                memberId);
        }

        public void Leave(string reason = "")
        {
            LiveDate = DateTime.UtcNow;
        }
    }
}
