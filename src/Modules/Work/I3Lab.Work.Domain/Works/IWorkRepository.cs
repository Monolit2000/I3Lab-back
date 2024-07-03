using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.Treatment;

namespace I3Lab.Works.Domain.Works
{
    public interface IWorkRepository
    {
        Task<Work> GetByIdAsync(WorkId id);
        Task<IEnumerable<Work>> GetAllAsync();
        Task<IEnumerable<Work>> GetAllByMemberIdAsync(MemberId id);
        Task<IEnumerable<Work>> GetAllByTreatmentIdAsync(TreatmentId id);
        Task AddAsync(Work work);
        Task UpdateAsync(Work work);
        Task DeleteAsync(WorkId id);
    }
}
