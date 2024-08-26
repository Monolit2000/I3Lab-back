using I3Lab.BuildingBlocks.Domain;
using I3Lab.Doctors.Domain.Doctors;

namespace I3Lab.Doctors.Domain.Clinics
{
    public class Clinic : Entity, IAggregateRoot
    {
        public ClinicId Id { get; private set; }
        public ClinicName ClinicName { get; private set; }
        public ClinicAddress Address { get; private set; }

        private readonly List<Doctor> _doctors = [];
        public IReadOnlyCollection<Doctor> Doctors => _doctors.AsReadOnly();

        public DateTime CreatedAt { get; private set; }
        public static Clinic Create(
            ClinicName clinicName,
            ClinicAddress address)
        {
            return new Clinic(
                clinicName,
                address);
        }

        private Clinic(
            ClinicName clinicName,
            ClinicAddress address)
        {
            Id = new ClinicId(Guid.NewGuid());
            ClinicName = clinicName;
            Address = address;
            CreatedAt = DateTime.UtcNow;
        }


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

        public void AddDoctor(Doctor doctor)
        {
            if (_doctors.Any(d => d.Id == doctor.Id))
                throw new InvalidOperationException("Doctor already exists in this clinic.");

            _doctors.Add(doctor);
        }

        public void RemoveDoctor(DoctorId doctorId)
        {
            var doctor = _doctors.FirstOrDefault(d => d.Id == doctorId);
            if (doctor == null)
                throw new InvalidOperationException("Doctor does not exist in this clinic.");

            _doctors.Remove(doctor);
        }
    }
}
