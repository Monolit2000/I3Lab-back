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

        public async Task<I3Lab.Treatments.Domain.TreatmentStages.TreatmentStage> GetByIdAsync(TreatmentStageId id, CancellationToken cancellationToken = default)
        {
            return await _context.Works
                .Include(w => w.WorkFiles)
                .FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<IEnumerable<I3Lab.Treatments.Domain.TreatmentStages.TreatmentStage>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Works
                .Include(w => w.WorkFiles)
                .ToListAsync();
        }

        public async Task<IEnumerable<I3Lab.Treatments.Domain.TreatmentStages.TreatmentStage>> GetAllByMemberIdAsync(MemberId id, CancellationToken cancellationToken = default)
        {
            return await _context.Works
                .Include(w => w.WorkFiles)
                .ToListAsync();
        }

        public async Task<IEnumerable<I3Lab.Treatments.Domain.TreatmentStages.TreatmentStage>> GetAllByTreatmentIdAsync(TreatmentId id, CancellationToken cancellationToken = default)
        {
            return await _context.Works
                .Include(w => w.WorkFiles)
                .ToListAsync();
        }

        public async Task AddAsync(I3Lab.Treatments.Domain.TreatmentStages.TreatmentStage work, CancellationToken cancellationToken = default)
        {
            await _context.Works.AddAsync(work);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(I3Lab.Treatments.Domain.TreatmentStages.TreatmentStage work, CancellationToken cancellationToken = default)
        {
            _context.Works.Update(work);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TreatmentStageId id, CancellationToken cancellationToken = default)
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
