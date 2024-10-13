using I3Lab.BuildingBlocks.Domain;
using I3Lab.Clinics.Domain.Doctors;

namespace I3Lab.Clinics.Domain.Clinics.Events
{
    public class ClinicDoctorAddedDomainEvent : DomainEventBase
    {
        public DoctorId DoctorId { get; set; }
        public ClinicId ClinicId { get; set; }

        public ClinicDoctorAddedDomainEvent(
            DoctorId doctorId,
            ClinicId clinicId)
        {
            DoctorId = doctorId;
            ClinicId = clinicId;
        }
    }
}
