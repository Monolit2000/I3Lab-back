using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Domain.TreatmentFiles
{
    public class BlobFileType : ValueObject
    {
        public string Value { get; }

        internal static BlobFileType Document => new BlobFileType(nameof(Document));
        internal static BlobFileType File3D => new BlobFileType(nameof(File3D));
        public static BlobFileType Image => new BlobFileType(nameof(Image));
        internal static BlobFileType Detail => new BlobFileType(nameof(Detail));
        internal static BlobFileType Video => new BlobFileType(nameof(Video));
        internal static BlobFileType Audio => new BlobFileType(nameof(Audio));

        private BlobFileType(string value)
        {
            Value = value;
        }
    }
}
