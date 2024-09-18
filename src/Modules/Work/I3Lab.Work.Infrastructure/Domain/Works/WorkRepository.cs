using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.Treatments;
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

        public async Task<I3Lab.Works.Domain.Works.Work> GetByIdAsync(WorkId id, CancellationToken cancellationToken = default)
        {
            return await _context.Works
                .Include(w => w.WorkFiles)
                .FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<IEnumerable<I3Lab.Works.Domain.Works.Work>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Works
                .Include(w => w.WorkFiles)
                .ToListAsync();
        }

        public async Task<IEnumerable<I3Lab.Works.Domain.Works.Work>> GetAllByMemberIdAsync(MemberId id, CancellationToken cancellationToken = default)
        {
            return await _context.Works
                .Include(w => w.WorkFiles)
                .ToListAsync();
        }

        public async Task<IEnumerable<I3Lab.Works.Domain.Works.Work>> GetAllByTreatmentIdAsync(TreatmentId id, CancellationToken cancellationToken = default)
        {
            return await _context.Works
                .Include(w => w.WorkFiles)
                .ToListAsync();
        }

        public async Task AddAsync(I3Lab.Works.Domain.Works.Work work, CancellationToken cancellationToken = default)
        {
            await _context.Works.AddAsync(work);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(I3Lab.Works.Domain.Works.Work work, CancellationToken cancellationToken = default)
        {
            _context.Works.Update(work);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(WorkId id, CancellationToken cancellationToken = default)
        {
            var work = await GetByIdAsync(id);
            if (work != null)
            {
                _context.Works.Remove(work);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
            => await _context.SaveChangesAsync();
    }
}
