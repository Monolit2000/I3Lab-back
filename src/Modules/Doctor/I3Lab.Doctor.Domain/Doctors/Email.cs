using I3Lab.BuildingBlocks.Domain;

namespace I3Lab.Doctors.Domain.Doctors
{
    public class Email : ValueObject
    {
        public string Value { get; }

        private Email(string value)
            => Value = value;
        
        public static Email Create(string value) 
            => new Email(value);
    }
}
