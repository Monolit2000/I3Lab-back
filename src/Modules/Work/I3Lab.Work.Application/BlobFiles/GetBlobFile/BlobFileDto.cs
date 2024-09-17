using System.Text.Json.Serialization;

namespace I3Lab.Works.Application.BlobFiles.GetBlobFile
{
    public class BlobFileDto
    {
        public Stream Stream { get; set; }

        public string ContentType { get; set; }

        public BlobFileDto(
            Stream stream, 
            string contentType)
        {
            Stream = stream;
            ContentType = contentType;
        }
    }
}
