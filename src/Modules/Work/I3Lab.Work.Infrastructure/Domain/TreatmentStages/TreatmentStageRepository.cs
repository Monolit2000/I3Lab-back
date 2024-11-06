using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Domain.TreatmentStages;
using I3Lab.Treatments.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace I3Lab.Treatments.Infrastructure.Domain.Works
{
    public class TreatmentStageRepository : ITreatmentStageRepository
    {
        private readonly TreatmentContext _context;

        public TreatmentStageRepository(TreatmentContext context)
        {
            _context = context;
        }

        public async Task<TreatmentStage> GetByIdAsync(TreatmentStageId id, CancellationToken cancellationToken = default)
        {
            return await _context.TreatmentStages
                .Include(w => w.TreatmentStageFiles)
                .FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<IEnumerable<TreatmentStage>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.TreatmentStages
                .Include(w => w.TreatmentStageFiles)
                .ToListAsync();
        }

        public async Task<IEnumerable<TreatmentStage>> GetAllByMemberIdAsync(MemberId id, CancellationToken cancellationToken = default)
        {
            return await _context.TreatmentStages
                .Include(w => w.TreatmentStageFiles)
                .ToListAsync();
        }

        public async Task<IEnumerable<TreatmentStage>> GetAllByTreatmentIdAsync(TreatmentId id, CancellationToken cancellationToken = default)
        {
            return await _context.TreatmentStages
                .Include(w => w.TreatmentStageFiles)
                .Where(x => x.TreatmentId == id)
                .ToListAsync();
        }

        public async Task AddAsync(TreatmentStage work, CancellationToken cancellationToken = default)
        {
            await _context.TreatmentStages.AddAsync(work);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TreatmentStage work, CancellationToken cancellationToken = default)
        {
            _context.TreatmentStages.Update(work);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TreatmentStageId id, CancellationToken cancellationToken = default)
        {
            var work = await GetByIdAsync(id);
            if (work != null)
            {
                _context.TreatmentStages.Remove(work);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
            => await _context.SaveChangesAsync();
    }
}
