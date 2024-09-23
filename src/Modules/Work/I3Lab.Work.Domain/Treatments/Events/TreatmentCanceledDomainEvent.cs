using I3Lab.BuildingBlocks.Domain;

namespace I3Lab.Treatments.Domain.Treatments.Events
{
    public class TreatmentCanceledDomainEvent : DomainEventBase
    {
        public Guid TreatmentId { get; }
        public DateTime date { get; }

        public TreatmentCanceledDomainEvent(Guid treatmentId, DateTime date)
        {
            TreatmentId = treatmentId;
            this.date = date;
        }
    }
}