using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.Treatments;

namespace I3Lab.Treatments.Domain.TreatmentFiles.Events
{
    public class TreatmentFileCreatedDomainEvent : DomainEventBase
    {
        public TreatmentId TreatmentId { get; set; }
        public TreatmentFileId TreatmentFileId { get; set; }

        public TreatmentFileCreatedDomainEvent(
            TreatmentId treatmentId,
            TreatmentFileId id)
        {
            TreatmentId = treatmentId;
            TreatmentFileId = id;
        }
    }
}
