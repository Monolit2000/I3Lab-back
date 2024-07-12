using I3Lab.Works.Domain.BlobFiles;
using I3Lab.Works.Domain.WorkDirectorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.BlobFiles.GetBlobFile
{
    public class BlobFileDto
    {
        public Stream Stream { get; set; }

        public BlobFileDto()
        {
                
        }
        public BlobFileDto(
            Stream stream)
        {
            Stream = stream;
        }
    }
}
