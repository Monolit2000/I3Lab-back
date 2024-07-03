using I3Lab.Works.Domain.Works;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Domain.WorkComments
{
    public interface IWorkCommentRepository
    {
        Task<WorkComment> GetByIdAsync(WorkCommentId id);
        Task<IEnumerable<WorkComment>> GetAllAsync();
        Task<IEnumerable<WorkComment>> GetAllByWorkIdAsync(WorkId workId);
        Task AddAsync(WorkComment workComment);
        Task UpdateAsync(WorkComment workComment);
        Task DeleteAsync(WorkCommentId id);

    }
}
