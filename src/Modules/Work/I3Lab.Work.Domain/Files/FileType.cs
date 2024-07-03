using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Domain.Files
{
    public class FileType : ValueObject
    {
        public string Value { get; }

        internal static FileType Document => new FileType(nameof(Document));
        internal static FileType File3D => new FileType(nameof(File3D));
        internal static FileType Image => new FileType(nameof(Image));
        internal static FileType Detail => new FileType(nameof(Detail));
        internal static FileType Video => new FileType(nameof(Video));
        internal static FileType Audio => new FileType(nameof(Audio));

        private FileType(string value)
        {
            Value = value;
        }
    }
}
