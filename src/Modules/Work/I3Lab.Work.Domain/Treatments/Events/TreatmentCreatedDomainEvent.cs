using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Domain.Treatments.Events
{
    public class TreatmentCreatedDomainEvent : DomainEventBase
    {
        public Guid TreatmentId { get; set; }

        public Guid CreatorId { get; set; }

        public TreatmentCreatedDomainEvent(
            Guid creatorId, 
            Guid treatmentId)
        {
            CreatorId = creatorId;
            TreatmentId = treatmentId;
        }
    }
}
