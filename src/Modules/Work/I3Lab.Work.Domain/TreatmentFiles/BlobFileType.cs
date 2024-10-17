using I3Lab.BuildingBlocks.Domain;

namespace I3Lab.Treatments.Domain.TreatmentFiles
{
    public class BlobFileType : ValueObject
    {
        public string Value { get; }

        public static BlobFileType Image => new BlobFileType(nameof(Image));
        internal static BlobFileType Video => new BlobFileType(nameof(Video));
        internal static BlobFileType Audio => new BlobFileType(nameof(Audio));
        internal static BlobFileType File3D => new BlobFileType(nameof(File3D));
        internal static BlobFileType Detail => new BlobFileType(nameof(Detail));
        internal static BlobFileType Document => new BlobFileType(nameof(Document));

        private static readonly HashSet<string> ValidTypes = new HashSet<string>
        {
            nameof(Document),
            nameof(File3D),
            nameof(Image),
            nameof(Detail),
            nameof(Video),
            nameof(Audio)
        };

        private BlobFileType(string value)
        {
            Value = value;
        }

        public static BlobFileType Create(string value)
        {
            return new BlobFileType(nameof(value));    
        }
    }
}
