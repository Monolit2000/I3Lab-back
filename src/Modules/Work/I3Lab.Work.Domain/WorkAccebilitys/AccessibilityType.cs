using I3Lab.BuildingBlocks.Domain;

namespace I3Lab.Works.Domain.WorkAccebilitys
{
    public class AccessibilityType : ValueObject
    {
        public string Value { get; }
        public static AccessibilityType Edit => new AccessibilityType(nameof(Edit));
        public static AccessibilityType ReadOnly => new AccessibilityType(nameof(ReadOnly));

        private AccessibilityType(string value)
        {
            Value = value;
        }
    }
}