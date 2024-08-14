using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.Works;

namespace I3Lab.Works.Domain.WorkComments
{
    public interface IWorkCommentRepository
    {
        Task<WorkComment> GetByIdAsync(WorkCommentId id);
        Task<IEnumerable<WorkComment>> GetAllAsync();
        Task<IEnumerable<WorkComment>> GetAllByWorkIdAsync(WorkId workId);
        Task<WorkComment> GetByMemberIdAsync(MemberId memberId);
        Task AddAsync(WorkComment workComment);
        Task UpdateAsync(WorkComment workComment);
        Task DeleteAsync(WorkCommentId id);
    }
}
