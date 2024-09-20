using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Domain.Treatments.Events
{
    public class MemberRemovedFromTreatmentDomainEvent : DomainEventBase
    {
        public MemberId MemberId { get; }
        public TreatmentId TreatmentId { get; }

        public MemberRemovedFromTreatmentDomainEvent(TreatmentId treatmentId, MemberId memberId)
        {
            TreatmentId = treatmentId;
            MemberId = memberId;
        }
    }
}
