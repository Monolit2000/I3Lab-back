using I3Lab.Works.Domain.BlobFiles;

namespace I3Lab.Works.Application.BlobFiles
{
    public class BlobFileDto
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string Type { get; set; }
        public DateTime CreateDate { get; set; }
        public string Accessibilitylevel { get; set; }

        public BlobFileDto(
            Guid id,
            string fileName, 
            string type,
            DateTime createDate, 
            string accessibilityLevel)
        {
            Id = id;
            FileName = fileName;
            Type = type;
            CreateDate = createDate;
            Accessibilitylevel = accessibilityLevel;
        }
    }
}
