using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.TreatmentStageComments;
using I3Lab.Treatments.Domain.TreatmentStages;
using I3Lab.Treatments.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace I3Lab.Treatments.Infrastructure.Domain.WorkComments
{
    public class TreatmentStageCommentRepository /*: IWorkCommentRepository*/
    {
        private readonly WorkContext _context;

        //public WorkCommentRepository(WorkContext context)
        //{
        //    _context = context;
        //}

        //public async Task<WorkComment> GetMemberByIdAsync(TreatmentStageCommentId id)
        //{
        //    var workComment = await _context.TreatmentStageComments
        //        .Include(wc => wc.PinedFiles)
        //        .FirstOrDefaultAsync(wc => wc.Id == id);

        //    return workComment;
        //}

        //public async Task<IEnumerable<WorkComment>> GetAllAsync()
        //{
        //    return await _context.TreatmentStageComments
        //        .Include(wc => wc.PinedFiles)
        //        .ToListAsync();
        //}

        //public async Task<IEnumerable<WorkComment>> GetAllByWorkIdAsync(TreatmentId workId)
        //{
        //    return await _context.TreatmentStageComments
        //        .Include(wc => wc.PinedFiles)
        //        .Where(wc => wc.TreatmentId == workId)
        //        .ToListAsync();
        //}

        //public async Task AddAsync(WorkComment workComment)
        //{
        //    await _context.TreatmentStageComments.AddAsync(workComment);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task UpdateAsync(WorkComment workComment)
        //{
        //    _context.TreatmentStageComments.Update(workComment);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task DeleteAsync(TreatmentStageCommentId id)
        //{
        //    var workComment = await GetMemberByIdAsync(id);
        //    if (workComment != null)
        //    {
        //        _context.TreatmentStageComments.Remove(workComment);
        //        await _context.SaveChangesAsync();
        //    }
        //}

        //public async Task<WorkComment?> GetByMemberIdAsync(MemberToInvite memberId)
        //{
        //    return await _context.TreatmentStageComments.FindAsync(memberId);
        //}
    }
}
