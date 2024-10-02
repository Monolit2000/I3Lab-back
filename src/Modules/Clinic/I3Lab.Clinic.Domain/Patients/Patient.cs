using I3Lab.BuildingBlocks.Domain;
using I3Lab.Clinics.Domain.Doctors;
using I3Lab.Clinics.Domain.Clinics;

namespace I3Lab.Clinics.Domain.Patients
{
    public class Patient : Entity, IAggregateRoot
    {
        public DoctorId Doctor { get; private set; }  
        public List<ClinicId> Clinics { get; private set; }
        
        public PatientId Id { get; }
        public PatientName Name { get; private set; }

        private Patient() { } //For Ef core

        private Patient(PatientName patientName)
        {
            Id = new PatientId(Guid.NewGuid());
            Name = patientName;
        }

        public static Patient Create(PatientName patientName)
            => new Patient(patientName); 

    }
}
