using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.BlobFiles;

namespace I3Lab.Treatments.Domain.TreatmentStages
{
    public class TreatmentMemberAccessibilityType : ValueObject
    {
        public string Value { get; }
        public static TreatmentMemberAccessibilityType Edit => new TreatmentMemberAccessibilityType(nameof(Edit));
        public static TreatmentMemberAccessibilityType ReadOnly => new TreatmentMemberAccessibilityType(nameof(ReadOnly));

        private TreatmentMemberAccessibilityType(string value)
        {
            Value = value;
        }
    }
}