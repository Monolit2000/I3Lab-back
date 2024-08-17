using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.WorkComments;
using I3Lab.Works.Domain.Works;
using I3Lab.Works.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace I3Lab.Works.Infrastructure.Domain.WorkComments
{
    public class WorkCommentRepository /*: IWorkCommentRepository*/
    {
        private readonly WorkContext _context;

        //public WorkCommentRepository(WorkContext context)
        //{
        //    _context = context;
        //}

        //public async Task<WorkComment> GetByIdAsync(WorkCommentId id)
        //{
        //    var workComment = await _context.WorkComments
        //        .Include(wc => wc.PinedFiles)
        //        .FirstOrDefaultAsync(wc => wc.Id == id);

        //    return workComment;
        //}

        //public async Task<IEnumerable<WorkComment>> GetAllAsync()
        //{
        //    return await _context.WorkComments
        //        .Include(wc => wc.PinedFiles)
        //        .ToListAsync();
        //}

        //public async Task<IEnumerable<WorkComment>> GetAllByWorkIdAsync(WorkId workId)
        //{
        //    return await _context.WorkComments
        //        .Include(wc => wc.PinedFiles)
        //        .Where(wc => wc.WorkId == workId)
        //        .ToListAsync();
        //}

        //public async Task AddAsync(WorkComment workComment)
        //{
        //    await _context.WorkComments.AddAsync(workComment);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task UpdateAsync(WorkComment workComment)
        //{
        //    _context.WorkComments.Update(workComment);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task DeleteAsync(WorkCommentId id)
        //{
        //    var workComment = await GetByIdAsync(id);
        //    if (workComment != null)
        //    {
        //        _context.WorkComments.Remove(workComment);
        //        await _context.SaveChangesAsync();
        //    }
        //}

        //public async Task<WorkComment?> GetByMemberIdAsync(MemberId memberId)
        //{
        //    return await _context.WorkComments.FindAsync(memberId);
        //}
    }
}
