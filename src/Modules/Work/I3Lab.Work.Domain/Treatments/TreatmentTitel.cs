using I3Lab.BuildingBlocks.Domain;

namespace I3Lab.Treatments.Domain.Treatments
{
    public class TreatmentTitel : ValueObject
    {
        public string Value { get; }

        private TreatmentTitel(string value)
        => Value = value;

        public static TreatmentTitel Create(string value)
        {
            return new TreatmentTitel(value);
        }
    }
}
