using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.Treatments;

namespace I3Lab.Works.Domain.Works
{
    public interface IWorkRepository
    {
        Task<Work?> GetByIdAsync(WorkId id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Work>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<Work>> GetAllByMemberIdAsync(MemberId id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Work>> GetAllByTreatmentIdAsync(TreatmentId id, CancellationToken cancellationToken = default);
        Task AddAsync(Work work, CancellationToken cancellationToken = default);
        Task UpdateAsync(Work work, CancellationToken cancellationToken = default);
        Task DeleteAsync(WorkId id, CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
