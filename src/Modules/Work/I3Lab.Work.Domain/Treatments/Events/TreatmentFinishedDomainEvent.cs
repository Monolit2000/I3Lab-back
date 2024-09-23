using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Domain.Treatments.Events
{
    public class TreatmentFinishedDomainEvent : DomainEventBase
    {
        public Guid TreatmentId { get; }
        public DateTime date { get; }

        public TreatmentFinishedDomainEvent(Guid treatmentId, DateTime date)
        {
            TreatmentId = treatmentId;
            this.date = date;
        }
    }
}
