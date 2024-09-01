using I3Lab.Doctors.Domain.Clinics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Doctors.Application.Doctors
{
    public class ClinicDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ClinicDto(Clinic clinic)
        {
            Id = clinic.Id.Value;
            Name = clinic.ClinicName.Name;
        }
    }
}
