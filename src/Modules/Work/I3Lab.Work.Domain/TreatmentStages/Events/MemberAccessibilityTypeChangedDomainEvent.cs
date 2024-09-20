using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Domain.TreatmentStages.Events
{
    public class MemberAccessibilityTypeChangedDomainEvent : DomainEventBase
    {
        public TreatmentStageId WorkId { get; }
        public Member MemberId { get; }
        public MemberAccessibilityType NewAccessibilityType { get; }

        public MemberAccessibilityTypeChangedDomainEvent(TreatmentStageId workId, Member memberId, MemberAccessibilityType newAccessibilityType)
        {
            WorkId = workId;
            MemberId = memberId;
            NewAccessibilityType = newAccessibilityType;
        }
    }
}
