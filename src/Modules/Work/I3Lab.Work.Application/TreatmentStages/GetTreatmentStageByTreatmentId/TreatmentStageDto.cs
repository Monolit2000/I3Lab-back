

namespace I3Lab.Treatments.Application.TreatmentStages.GetTreatmentStageByTreatmentId
{
    public class TreatmentStageDto
    {
        public Guid TreatmentId { get; set; }
        public Guid TreatmentStagId { get; set; }
        public string Titel { get; set; }
        public string Status { get; set; }

        public TreatmentStageDto(
            Guid treatmentId,
            Guid treatmentStagId,
            string titel,
            string status)
        {
            TreatmentId = treatmentId;
            TreatmentStagId = treatmentStagId;
            Titel = titel;
            Status = status;
        }
    }
}
