using I3Lab.Treatments.Domain.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Domain.Treatments
{
    public interface ITreatmentRepository
    {
        Task<bool> IsNameUniqueAsync(string name, CancellationToken cancellationToken = default);
        Task<Treatment> GetByIdAsync(TreatmentId id, CancellationToken cancellationToken = default);
        
        Task<IEnumerable<Treatment>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<List<Treatment>> GetAllByPatientAsync(MemberId patientId, CancellationToken cancellationToken = default);

        Task<Treatment> GetByTokenAsync(string token);

        Task AddAsync(Treatment treatment, CancellationToken cancellationToken = default);
        Task UpdateAsync(Treatment treatment, CancellationToken cancellationToken = default);
        Task DeleteAsync(TreatmentId id, CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
