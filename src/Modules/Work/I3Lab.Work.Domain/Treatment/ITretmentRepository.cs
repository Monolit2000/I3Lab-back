using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Domain.Treatment
{
    public interface ITretmentRepository
    {
        Task<bool> IsNameUniqueAsync(string name);
        Task<Treatment> GetByIdAsync(TreatmentId id, CancellationToken cancellationToken);
        Task<IEnumerable<Treatment>> GetAllAsync();
        Task AddAsync(Treatment treatment);
        Task UpdateAsync(Treatment treatment);
        Task DeleteAsync(TreatmentId id, CancellationToken cancellationToken);
        Task SaveChangesAsync();
    }
}
