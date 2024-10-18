using I3Lab.Treatments.Domain.TreatmentFiles;

namespace I3Lab.Treatments.Application.TreatmentFiles.GetTreatmentFilesByTreatmentStageId
{
    public class TreatmentFileDto
    {
        public string FileType { get; set; }
        public List<TreatmentFile> Files { get; set; }
    }
}
