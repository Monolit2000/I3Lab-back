using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Domain.TreatmentInvites
{
    public interface ITreatmentInviteRepository
    {
        Task<TreatmentInvite> GetByIdAsync(TreatmentInviteId id);
        Task AddAsync(TreatmentInvite invite);
        Task UpdateAsync(TreatmentInvite invite);
        Task DeleteAsync(TreatmentInviteId id);
    }
}
