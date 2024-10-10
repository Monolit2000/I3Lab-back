using I3Lab.Treatments.Domain.TreatmentFiles;

namespace I3Lab.Treatments.Application.TreatmentFiles
{
    public class TreatmentFileDto
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string Type { get; set; }
        public DateTime CreateDate { get; set; }

        public TreatmentFileDto(
            Guid id,
            string fileName, 
            string type,
            DateTime createDate)
        {
            Id = id;
            FileName = fileName;
            Type = type;
            CreateDate = createDate;
        }
    }
}
