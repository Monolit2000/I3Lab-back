using I3Lab.BuildingBlocks.Domain;
using I3Lab.Clinics.Domain.Clinics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Clinics.Domain.Doctors.Events
{
    public class ClinicAddedToDoctorDomainEvent : DomainEventBase
    {
        public DoctorId DoctorId { get; set; }
        public ClinicId ClinicId { get; set; }

        public ClinicAddedToDoctorDomainEvent(
            DoctorId doctorId,
            ClinicId clinicId)
        {
            DoctorId = doctorId;
            ClinicId = clinicId;
        }
    }
}
