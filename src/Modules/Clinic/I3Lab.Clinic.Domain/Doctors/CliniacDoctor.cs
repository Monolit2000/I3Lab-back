using I3Lab.BuildingBlocks.Domain;
using I3Lab.Clinics.Domain.Clinics;


namespace I3Lab.Clinics.Domain.Doctors
{
    public class ClinicDoctor : Entity
    {
        public ClinicId ClinicId { get; set; }

        public DoctorId DoctorId { get; set; }  

        public DateTime ClincAddedAt {  get; set; }

        private ClinicDoctor() { } //For Ef Core
        public ClinicDoctor(ClinicId clinicId, DoctorId doctorId)
        {
            ClinicId = clinicId;
            DoctorId = doctorId;
            ClincAddedAt = DateTime.UtcNow;
        }

        public static ClinicDoctor Create(
            ClinicId clinicId,
            DoctorId doctorId)
        {
            return new ClinicDoctor(
                clinicId,
                doctorId);
        }
    }
}
