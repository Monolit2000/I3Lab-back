using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Domain.Works.Events
{
    public class MemberAccessibilityTypeChangedDomainEvent : DomainEventBase
    {
        public WorkId WorkId { get; }
        public Member MemberId { get; }
        public MemberAccessibilityType NewAccessibilityType { get; }

        public MemberAccessibilityTypeChangedDomainEvent(WorkId workId, Member memberId, MemberAccessibilityType newAccessibilityType)
        {
            WorkId = workId;
            MemberId = memberId;
            NewAccessibilityType = newAccessibilityType;
        }
    }
}
