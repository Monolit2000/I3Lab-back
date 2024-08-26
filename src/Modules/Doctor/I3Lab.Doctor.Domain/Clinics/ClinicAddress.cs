using I3Lab.BuildingBlocks.Domain;

namespace I3Lab.Doctors.Domain.Clinics
{
    public class ClinicAddress : ValueObject
    {
        public string CityAddress { get; }

        private ClinicAddress(string address) 
            => CityAddress = address;

        public static ClinicAddress Create(string address)
        {
            return new ClinicAddress(address);
        }
    }
}
