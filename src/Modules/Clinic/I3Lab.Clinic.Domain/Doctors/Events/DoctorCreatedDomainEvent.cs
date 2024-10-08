using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Clinics.Domain.Doctors.Events
{
    public class DoctorCreatedDomainEvent : DomainEventBase
    {
        private Guid DoctorId { get; set; }
        private string FirstName { get; set; }
        private string FastName { get; set; }

        public DoctorCreatedDomainEvent(
            Guid doctorId,
            string firstName,
            string lastName)
        {
            DoctorId = doctorId;
            FirstName = firstName;
            FastName = lastName;
        }
    }
}
