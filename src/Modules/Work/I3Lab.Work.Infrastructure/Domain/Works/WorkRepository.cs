using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.Treatment;
using I3Lab.Works.Domain.Works;
using I3Lab.Works.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace I3Lab.Works.Infrastructure.Domain.Works
{
    public class WorkRepository : IWorkRepository
    {
        private readonly WorkContext _context;

        public WorkRepository(WorkContext context)
        {
            _context = context;
        }

        public async Task<Work> GetByIdAsync(WorkId id)
        {
            var work = await _context.Works
                .Include(w => w.WorkFiles)
                .Include(w => w.WorkMembers)
                .FirstOrDefaultAsync(w => w.Id == id);

            return work;
        }

        public async Task<IEnumerable<Work>> GetAllAsync()
        {
            return await _context.Works
                .Include(w => w.WorkFiles)
                .Include(w => w.WorkMembers)
                .ToListAsync();
        }

        public async Task<IEnumerable<Work>> GetAllByMemberIdAsync(MemberId id)
        {
            return await _context.Works
                .Include(w => w.WorkFiles)
                .Include(w => w.WorkMembers)
                .Where(w => w.WorkMembers.Any(m => m.MemberId == id))
                .ToListAsync();
        }

        public async Task<IEnumerable<Work>> GetAllByTreatmentIdAsync(TreatmentId id)
        {
            return await _context.Works
                .Include(w => w.WorkFiles)
                .Include(w => w.WorkMembers)
                .Where(w => w.TreatmentId == id)
                .ToListAsync();
        }

        public async Task AddAsync(Work work)
        {
            await _context.Works.AddAsync(work);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Work work)
        {
            _context.Works.Update(work);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(WorkId id)
        {
            var work = await GetByIdAsync(id);
            if (work != null)
            {
                _context.Works.Remove(work);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
