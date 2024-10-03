using I3Lab.BuildingBlocks.Domain;

namespace I3Lab.Doctors.Domain.Doctors
{
    public class Specialization : ValueObject
    {
        public string Value { get; }

        private Specialization(string value)
            => Value = value;   

        public static Specialization Create(string value)
        {
            return new Specialization(value);    
        }
    }
}
