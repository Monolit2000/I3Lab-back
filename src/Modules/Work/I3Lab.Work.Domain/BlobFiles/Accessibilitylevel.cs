using I3Lab.BuildingBlocks.Domain;
using System.Reflection.Metadata;

namespace I3Lab.Works.Domain.BlobFiles
{
    public class Accessibilitylevel : ValueObject
    {
        public static Accessibilitylevel Hot => new Accessibilitylevel(nameof(Hot));
        public static Accessibilitylevel Cool => new Accessibilitylevel(nameof(Cool));
        public static Accessibilitylevel Cold => new Accessibilitylevel(nameof(Cold));
        public static Accessibilitylevel Archive => new Accessibilitylevel(nameof(Archive));

        public string Value { get; }

        private Accessibilitylevel(string value)
        {
            Value = value;
        }

    }
}