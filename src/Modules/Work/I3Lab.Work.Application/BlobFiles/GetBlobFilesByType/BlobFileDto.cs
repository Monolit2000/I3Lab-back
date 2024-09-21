using I3Lab.Treatments.Domain.BlobFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.BlobFiles.GetBlobFilesByType
{
    public class BlobFileDto
    {
        public string FileType { get; set; }
        public List<BlobFile> Files { get; set; }
    }
}
