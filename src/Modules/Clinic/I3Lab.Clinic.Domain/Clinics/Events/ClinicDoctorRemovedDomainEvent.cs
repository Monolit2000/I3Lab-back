using I3Lab.BuildingBlocks.Domain;
using I3Lab.Clinics.Domain.Doctors;

namespace I3Lab.Clinics.Domain.Clinics
{
    public class ClinicDoctorRemovedDomainEvent : DomainEventBase
    {
        public ClinicId ClinicId { get; set; }
        public DoctorId DoctorId { get; set; }

        public ClinicDoctorRemovedDomainEvent(
            ClinicId clinicId,
            DoctorId doctorId)
        {
            ClinicId = clinicId;
            DoctorId = doctorId;
        }
    }
}