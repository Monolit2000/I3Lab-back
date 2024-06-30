using I3Lab.BuildingBlocks.Domain;
using System.Reflection.Metadata;

namespace I3Lab.Work.Domain.Files
{
    public class Accessibilitylevel : ValueObject
    {
        public string Value { get; }
        public static Accessibilitylevel Hot => new Accessibilitylevel(nameof(Hot));
        public static Accessibilitylevel Cool => new Accessibilitylevel(nameof(Cool));
        public static Accessibilitylevel Cold => new Accessibilitylevel(nameof(Cold));
        public static Accessibilitylevel Archive => new Accessibilitylevel(nameof(Archive));

        private Accessibilitylevel(string value)
        {
            Value = value;
        }

    }
}