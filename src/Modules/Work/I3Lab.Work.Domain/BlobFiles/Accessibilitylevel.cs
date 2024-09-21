using FluentResults;
using I3Lab.BuildingBlocks.Domain;

namespace I3Lab.Treatments.Domain.BlobFiles
{
    public class Accessibilitylevel : ValueObject
    {
        public static Accessibilitylevel Hot => new Accessibilitylevel(nameof(Hot));
        public static Accessibilitylevel Cool => new Accessibilitylevel(nameof(Cool));
        public static Accessibilitylevel Cold => new Accessibilitylevel(nameof(Cold));
        public static Accessibilitylevel Archive => new Accessibilitylevel(nameof(Archive));

        public string Value { get; }

        private static readonly HashSet<string> ValidLevels = new HashSet<string>
        {
            nameof(Hot),
            nameof(Cool),
            nameof(Cold),
            nameof(Archive)
        };

        private Accessibilitylevel(string value)
        {
            Value = value;
        }

        public static Result<Accessibilitylevel> Create(string value)
        {
            if (!ValidLevels.Contains(value))
                return Result.Fail($"Invalid accessibility level value: {value}");

            return new Accessibilitylevel(value);
        }
    }
}
