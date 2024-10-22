using I3Lab.Clinics.Domain.Doctors;

namespace I3Lab.Clinics.Application.Doctors
{
    public class DoctorDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string DoctorAvatarUrl { get; set; }
        //public List<ClinicDto> Clinics { get; set; } = [];
      
        public DoctorDto(Doctor doctor)
        {
            Id = doctor.Id.Value;
            FirstName = doctor.Name.FirstName;
            LastName = doctor.Name.LastName;
            Email = doctor.Email.Value;
            PhoneNumber = doctor.PhoneNumber.Value;
            DoctorAvatarUrl = doctor.DoctorAvatar.Url;
            //Clinics = doctor.Clinics.Select(c => new ClinicDto(c)).ToList();
        }
    }
}
