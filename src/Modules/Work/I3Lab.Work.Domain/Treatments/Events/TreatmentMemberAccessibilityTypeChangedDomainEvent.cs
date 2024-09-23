using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.TreatmentStages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Domain.Treatments.Events
{
    public class TreatmentMemberAccessibilityTypeChangedDomainEvent : DomainEventBase
    {
        public TreatmentId TreatmentId { get; }
        public Member MemberId { get; }
        public TreatmentMemberAccessibilityType NewAccessibilityType { get; }

        public TreatmentMemberAccessibilityTypeChangedDomainEvent(
            TreatmentId treatmentId, 
            Member memberId, 
            TreatmentMemberAccessibilityType newAccessibilityType)
        {
            TreatmentId = treatmentId;
            MemberId = memberId;
            NewAccessibilityType = newAccessibilityType;
        }
    }
}
