using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Domain.Treatments.Events
{
    public class MemberRemovedFromTreatmentDomainEvent : DomainEventBase
    {
        public Guid TreatmentId { get; }
        public Guid MemberId { get; }

        public MemberRemovedFromTreatmentDomainEvent(Guid treatmentId, Guid memberId)
        {
            TreatmentId = treatmentId;
            MemberId = memberId;
        }
    }
}
