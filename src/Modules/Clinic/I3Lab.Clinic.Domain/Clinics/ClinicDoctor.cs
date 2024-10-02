using I3Lab.Clinics.Domain.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace I3Lab.Clinics.Domain.Clinics
{
    public class ClinicDoctor
    {
        public DoctorId DoctorId { get; set; }  

        public DateTime AddedAt { get; set; }

        private ClinicDoctor() { }// For EF Core
            
        public ClinicDoctor(DoctorId doctorId)
        {
            DoctorId = doctorId;
            AddedAt = DateTime.UtcNow;
        }

        public static ClinicDoctor Create(DoctorId doctorId)
        {
            return new ClinicDoctor(doctorId);
        }

    }
}
