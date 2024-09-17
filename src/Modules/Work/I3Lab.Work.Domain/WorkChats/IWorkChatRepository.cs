using I3Lab.Works.Domain.Works;

namespace I3Lab.Works.Domain.WorkChats
{
    public interface IWorkChatRepository
    {
        Task<WorkChat> GetByIdAsync(WorkChatId id, CancellationToken cancellationToken = default);
        Task<WorkChat> GetByWorkIdAsync(WorkId workId, CancellationToken cancellationToken = default);
        Task AddAsync(WorkChat workChat, CancellationToken cancellationToken = default);
        Task UpdateAsync(WorkChat workChat, CancellationToken cancellationToken = default);
        Task RemoveAsync(WorkChat workChat, CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
