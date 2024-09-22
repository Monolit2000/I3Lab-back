using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Domain.TreatmentStageChats;
using I3Lab.Treatments.Domain.TreatmentStages;
using I3Lab.Treatments.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace I3Lab.Treatments.Infrastructure.Domain.WorkChats
{
    public class TreatmentStageChatRepository : ITreatmentStageChatRepository
    {
        private readonly TreatmentContext _context;

        public TreatmentStageChatRepository(TreatmentContext context)
        {
            _context = context;
        }

        public async Task<TreatmentStageChat> GetByIdAsync(TreatmentStageChatId id, CancellationToken cancellationToken = default)
        {
            return await _context.WorkChats
                .AsSplitQuery() 
                .Include(wc => wc.Messages)
                .Include(wc => wc.ChatMembers)
                .FirstOrDefaultAsync(wc => wc.Id == id, cancellationToken);
        }

        public async Task<TreatmentStageChat> GetByTreatmentStageIdAsync(TreatmentStageId workId, CancellationToken cancellationToken = default)
        {
            return await _context.WorkChats
                .AsSplitQuery() 
                .Include(wc => wc.Messages)
                .Include(wc => wc.ChatMembers)
                .FirstOrDefaultAsync(wc => wc.TreatmentStageId == workId, cancellationToken);
        }

        public async Task<List<TreatmentStageChat>> GetAllByTreatmentStageId(TreatmentStageId treatmentStageId, CancellationToken cancellationToken = default)
        {
            return await _context.WorkChats
                .AsSplitQuery() 
                .Include(wc => wc.Messages)
                .Include(wc => wc.ChatMembers)
                .Where(wc => wc.TreatmentStageId == treatmentStageId)
                .ToListAsync(cancellationToken);
        }
        public async Task<List<TreatmentStageChat>> GetAllByTreatmentIdAsync(TreatmentId treatmentId, CancellationToken cancellationToken = default)
        {
            return await _context.WorkChats
                  .AsSplitQuery()
                  .Include(wc => wc.Messages)
                  .Include(wc => wc.ChatMembers)
                  .Where(wc => wc.TreatmentId == treatmentId)
                  .ToListAsync(cancellationToken);
        }

        public async Task AddAsync(TreatmentStageChat workChat, CancellationToken cancellationToken = default)
        {
            await _context.WorkChats.AddAsync(workChat, cancellationToken);
        }

        public Task UpdateAsync(TreatmentStageChat workChat, CancellationToken cancellationToken = default)
        {
            _context.WorkChats.Update(workChat);
            return Task.CompletedTask;
        }

        public Task RemoveAsync(TreatmentStageChat workChat, CancellationToken cancellationToken = default)
        {
            _context.WorkChats.Remove(workChat);
            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync();
        }
    }
}
