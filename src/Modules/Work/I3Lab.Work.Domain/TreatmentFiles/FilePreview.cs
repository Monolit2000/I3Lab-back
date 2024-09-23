using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Domain.TreatmentFiles
{
    public class FilePreview : ValueObject
    {
        public string BlobFileUrl { get; }

        private FilePreview(string url) 
            => BlobFileUrl = url;

        public static FilePreview Create(string url) 
            => new FilePreview(url);   
    }
}
