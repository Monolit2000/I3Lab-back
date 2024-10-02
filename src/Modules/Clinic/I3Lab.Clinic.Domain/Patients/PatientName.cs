using I3Lab.BuildingBlocks.Domain;

namespace I3Lab.Clinics.Domain.Patients
{
    public class PatientName : ValueObject
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        private PatientName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public static PatientName Create(string firstName, string lastName)
        {
            return new PatientName(firstName, lastName);
        }
    }
}
