using I3Lab.Treatments.Domain.Treatments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Domain.TreatmentInvites
{
    public interface ITreatmentInviteRepository
    {
        Task<List<TreatmentInvite>> GetAllByTreatmentIdAsync(TreatmentId treatmentId);
        Task<TreatmentInvite> GetByIdAsync(TreatmentInviteId id);
        Task<TreatmentInvite> GetByTokenAsync(string token);
        Task AddAsync(TreatmentInvite invite);
        Task UpdateAsync(TreatmentInvite invite);
        Task DeleteAsync(TreatmentInviteId id);
        Task SaveChangesAsync();
    }
}
