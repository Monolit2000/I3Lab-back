using I3Lab.Clinics.Domain.Clinics;

namespace I3Lab.Clinics.Domain.Clnics
{
    public interface IClinicRepository
    {
        Task<Clinic> GetById(ClinicId clinicId);

        Task<List<Clinic>> GetAll();

    }
}
