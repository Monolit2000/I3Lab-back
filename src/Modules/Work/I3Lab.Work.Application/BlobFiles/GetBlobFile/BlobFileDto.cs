using System.Text.Json.Serialization;

namespace I3Lab.Works.Application.BlobFiles.GetBlobFile
{
    public class BlobFileDto
    {
        public Stream Stream { get; set; }

        public BlobFileDto()
        {
        }
        [JsonConstructor]
        public BlobFileDto(
            Stream stream)
        {
            Stream = stream;
        }
    }
}
