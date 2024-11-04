using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.TreatmentStageComments;
using I3Lab.Treatments.Domain.TreatmentStages;
using I3Lab.Treatments.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace I3Lab.Treatments.Infrastructure.Domain.WorkComments
{
    public class TreatmentStageCommentRepository /*: IWorkCommentRepository*/
    {
        private readonly TreatmentContext _context;

        //public WorkCommentRepository(TreatmentContext context)
        //{
        //    _context = context;
        //}

        //public async Task<WorkComment> GetAsync(TreatmentStageCommentId id)
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

        //public async Task<IEnumerable<WorkComment>> GetAllByTreatmentStageIdAsync(TreatmentId workId)
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

        //public async Task DeleteByIdIfExistAsync(TreatmentStageCommentId id)
        //{
        //    var workComment = await GetAsync(id);
        //    if (workComment != null)
        //    {
        //        _context.TreatmentStageComments.Remove(workComment);
        //        await _context.SaveChangesAsync();
        //    }
        //}

        //public async Task<WorkComment?> GetByMemberIdAsync(InvitedMember memberId)
        //{
        //    return await _context.TreatmentStageComments.FindAsync(memberId);
        //}
    }
}
