using I3Lab.BuildingBlocks.Domain;
using I3Lab.Clinics.Domain.Doctors;

namespace I3Lab.Clinics.Domain.Clinics
{
    public class Clinic : Entity, IAggregateRoot
    {
        public List<ClinicDoctor> ClinicDoctors = [];

        public ClinicId Id { get; private set; }
        public ClinicName ClinicName { get; private set; }
        public ClinicAddress Address { get; private set; }
        public ClinicStatus Status { get; set; }

        public DateTime CreatedAt { get; private set; }

        private Clinic() { }// For EF Core    

        private Clinic(
            ClinicName clinicName,
            ClinicAddress address)
        {
            Id = new ClinicId(Guid.NewGuid());
            ClinicName = clinicName;
            Address = address;
            Status = ClinicStatus.Active;
            CreatedAt = DateTime.UtcNow;
        }
        public static Clinic Create(ClinicName clinicName, ClinicAddress address) 
            => new Clinic(clinicName, address);

        public void UpdateInfo(
            ClinicName clinicName,
            ClinicAddress address)
        {
            ClinicName = clinicName;
            Address = address;
        }

        public void UpdateAddress(ClinicAddress newAddress)
        {
            Address = newAddress;
        }

        public void UpdateName(ClinicName newName)
        {
            ClinicName = newName;
        }

        public void AddDoctor(DoctorId doctorId)
        {
            if (ClinicDoctors.Any(d => d.DoctorId == doctorId))
                throw new InvalidOperationException("Doctor already exists in this clinic.");

            ClinicDoctors.Add(ClinicDoctor.Create(this.Id, doctorId));
        }

        public void RemoveDoctor(DoctorId doctorId)
        {
            var doctor = ClinicDoctors.FirstOrDefault(d => d.DoctorId == doctorId);
            if (doctor == null)
                throw new InvalidOperationException("Doctor does not exist in this clinic.");

            ClinicDoctors.Remove(doctor);
        }
    }
}
