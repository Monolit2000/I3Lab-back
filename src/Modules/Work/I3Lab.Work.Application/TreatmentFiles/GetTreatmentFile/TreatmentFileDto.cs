using System.Text.Json.Serialization;

namespace I3Lab.Treatments.Application.TreatmentFiles.GetTreatmentFile
{
    public class TreatmentFileDto
    {
        public Stream Stream { get; set; }

        public string ContentType { get; set; }

        public TreatmentFileDto(
            Stream stream, 
            string contentType)
        {
            Stream = stream;
            ContentType = contentType;
        }
    }
}
