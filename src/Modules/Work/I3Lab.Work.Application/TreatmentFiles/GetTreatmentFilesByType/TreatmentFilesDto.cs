using I3Lab.Treatments.Domain.TreatmentFils;

namespace I3Lab.Treatments.Application.TreatmentFiles.GetBlobFilesByType
{
    public class TreatmentFilesDto
    {
        public string FileType { get; set; }
        public List<TreatmentFile> Files { get; set; }
    }
}
