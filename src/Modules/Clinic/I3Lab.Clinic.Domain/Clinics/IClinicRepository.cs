using I3Lab.Clinics.Domain.Clinics;

namespace I3Lab.Clinics.Domain.Clinics
{
    public interface IClinicRepository
    {
        Task<Clinic?> GetByIdAsync(ClinicId clinicId);

        Task<bool> ExistByName(ClinicName clinicName);

        Task<List<Clinic>> GetAllAsync();

        Task AddAsync(Clinic doctor);

        Task DeleteAsync(Clinic doctor);

        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
