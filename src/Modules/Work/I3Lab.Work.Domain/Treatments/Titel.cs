using I3Lab.BuildingBlocks.Domain;

namespace I3Lab.Works.Domain.Treatments
{
    public class Titel : ValueObject
    {
        public string Value { get; }

        private Titel(string value)
        => Value = value;

        public static Titel Create(string value)
        {
            return new Titel(value);
        }
    }
}
