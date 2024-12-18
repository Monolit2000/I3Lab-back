﻿using I3Lab.BuildingBlocks.Domain;
using I3Lab.Clinics.Domain.Doctors;

namespace I3Lab.Clinics.Domain.Clinics
{
    public class ClinicDoctor : IAggregateRoot
    {
        public DoctorId DoctorId { get; set; }  

        public ClinicId ClinicId { get; set; }

        public DateTime AddedAt { get; set; }

        public DateTime? RemovedAt { get; set; }     

        private ClinicDoctor() { } // For EF Core
            
        public ClinicDoctor(ClinicId clinicId, DoctorId doctorId)
        {
            ClinicId = clinicId;
            DoctorId = doctorId;
            AddedAt = DateTime.UtcNow;
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
