using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Modules.BlobFailes.Application.BlobFiles.GetBlobFileById
{
    public class BlobFileDto
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string Uri { get; set; }
        public DateTime CreateDate { get; set; }
        public string Accessibilitylevel { get; set; }

        public BlobFileDto(
            Guid id,
            string uri,
            string fileName,
            DateTime createDate,
            string accessibilityLevel)
        {
            Id = id;
            Uri = uri;
            FileName = fileName;
            CreateDate = createDate;
            Accessibilitylevel = accessibilityLevel;
        }
    }
}
