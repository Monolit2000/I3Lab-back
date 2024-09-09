using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.Works;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Domain.Treatments.Events
{
    public class TreatmentMemberAccessibilityTypeChangedDomainEvent : DomainEventBase
    {
        public TreatmentId TreatmentId { get; }
        public Member MemberId { get; }
        public MemberAccessibilityType NewAccessibilityType { get; }

        public TreatmentMemberAccessibilityTypeChangedDomainEvent(
            TreatmentId treatmentId, 
            Member memberId, 
            MemberAccessibilityType newAccessibilityType)
        {
            TreatmentId = treatmentId;
            MemberId = memberId;
            NewAccessibilityType = newAccessibilityType;
        }
    }
}
