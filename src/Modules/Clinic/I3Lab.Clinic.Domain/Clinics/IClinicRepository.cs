using I3Lab.Clinics.Domain.Clinics;
using I3Lab.Clinics.Domain.Doctors;

namespace I3Lab.Clinics.Domain.Clinics
{
    public interface IClinicRepository
    {
        Task<Clinic?> GetByIdAsync(ClinicId clinicId);

        Task<bool> ExistByName(ClinicName clinicName);

        Task<List<Clinic>> GetAllAsync();

        Task<List<Clinic>> GetAllClnicsByDoctorId(DoctorId id);

        Task<List<Clinic>> GetAllClnicsByDoctorIdV2(DoctorId id);

        Task AddAsync(Clinic doctor);

        Task DeleteAsync(Clinic doctor);

        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
