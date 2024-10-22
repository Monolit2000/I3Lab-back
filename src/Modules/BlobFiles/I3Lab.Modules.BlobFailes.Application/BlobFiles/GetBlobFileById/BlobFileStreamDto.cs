

namespace I3Lab.Modules.BlobFailes.Application.BlobFiles.GetBlobFileById
{
    public class BlobFileStreamDto
    {
        public Stream Stream { get; set; }

        public string ContentType { get; set; }

        public BlobFileStreamDto(
            Stream stream,
            string contentType)
        {
            Stream = stream;
            ContentType = contentType;
        }
    }
}
