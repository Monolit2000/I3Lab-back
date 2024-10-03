using I3Lab.Clinics.Domain.Clinics;

namespace I3Lab.Clinics.Domain.Clnics
{
    public interface IClinicRepository
    {
        Task<Clinic?> GetByIdAsync(ClinicId clinicId);

        Task<bool> ExistByName(ClinicName clinicName);

        Task<List<Clinic>> GetAll();

        Task AddAsync(Clinic doctor);

        Task DeleteAsync(Clinic doctor);


    }
}
