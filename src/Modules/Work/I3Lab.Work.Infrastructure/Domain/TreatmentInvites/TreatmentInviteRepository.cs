using I3Lab.Treatments.Domain.TreatmentInvites;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace I3Lab.Treatments.Infrastructure.Domain.TreatmentInvites
{
    public class TreatmentInviteRepository : ITreatmentInviteRepository
    {
        private readonly TreatmentContext _context;

        public TreatmentInviteRepository(TreatmentContext context)
        {
            _context = context;
        }

        public async Task<TreatmentInvite> GetByIdAsync(TreatmentInviteId id)
        {
            return await _context.TreatmentInvites
                .Include(x => x.Treatment)
                .Include(x => x.MemberToInvite)
                .Include(x => x.Inviter)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(TreatmentInvite invite)
        {
            await _context.TreatmentInvites.AddAsync(invite);
            await SaveChangesAsync();
        }

        public async Task UpdateAsync(TreatmentInvite invite)
        {
            _context.TreatmentInvites.Update(invite);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(TreatmentInviteId id)
        {
            var invite = await GetByIdAsync(id);
            if (invite != null)
            {
                _context.TreatmentInvites.Remove(invite);
                await SaveChangesAsync();
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<TreatmentInvite>> GetAllByTreatmentIdAsync(TreatmentId treatmentId)
        {
            return await _context.TreatmentInvites
                .Where(invite => invite.Treatment.Id == treatmentId)
                .Include(x => x.Treatment)
                .Include(x => x.MemberToInvite)
                .Include(x => x.Inviter)
                .ToListAsync();
        }
    }
}
