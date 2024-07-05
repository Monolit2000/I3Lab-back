using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Domain.Treatment
{
    public interface ITretmentRepository
    {
        Task<Treatment> GetByIdAsync(TreatmentId id);
        Task<IEnumerable<Treatment>> GetAllAsync();
        Task AddAsync(Treatment treatment);
        Task UpdateAsync(Treatment treatment);
        Task DeleteAsync(TreatmentId id);
    }
}
