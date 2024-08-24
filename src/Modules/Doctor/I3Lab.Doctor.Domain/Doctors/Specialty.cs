using I3Lab.BuildingBlocks.Domain;

namespace I3Lab.Doctors.Domain.Doctors
{
    public class Specialty : ValueObject
    {
        public string Value { get; }

        private Specialty(string value)
            => Value = value;   

        public static Specialty Create(string value)
        {
            return new Specialty(value);    
        }
    }
}
