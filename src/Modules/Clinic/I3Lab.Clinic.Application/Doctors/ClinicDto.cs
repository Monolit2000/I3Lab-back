using I3Lab.Clinics.Domain.Clinics;

namespace I3Lab.Clinics.Application.Doctors
{
    public class ClinicDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ClinicDto(Clinic clinic)
        {
            Id = clinic.Id.Value;
            Name = clinic.ClinicName.Value;
        }
    }
}
