using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Modules.BlobFailes.Application.BlobFiles.GetBlobFile
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
