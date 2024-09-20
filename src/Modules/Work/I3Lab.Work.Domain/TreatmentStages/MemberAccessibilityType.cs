using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.BlobFiles;

namespace I3Lab.Treatments.Domain.TreatmentStages
{
    public class MemberAccessibilityType : ValueObject
    {
        public string Value { get; }
        public static MemberAccessibilityType Edit => new MemberAccessibilityType(nameof(Edit));
        public static MemberAccessibilityType ReadOnly => new MemberAccessibilityType(nameof(ReadOnly));

        private MemberAccessibilityType(string value)
        {
            Value = value;
        }
    }
}