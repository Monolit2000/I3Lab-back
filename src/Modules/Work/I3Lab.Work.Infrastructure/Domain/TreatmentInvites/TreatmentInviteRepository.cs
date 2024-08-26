using I3Lab.Works.Domain.TreatmentInvites;
using I3Lab.Works.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Infrastructure.Domain.TreatmentInvites
{
    public class TreatmentInviteRepository : ITreatmentInviteRepository
    {
        private readonly WorkContext _context;

        public TreatmentInviteRepository(WorkContext context)
        {
            _context = context;
        }

        public async Task<TreatmentInvite?> GetByIdAsync(TreatmentInviteId id)
        {
            return await _context.TreatmentInvites.FindAsync(id);
        }

        public async Task AddAsync(TreatmentInvite invite)
        {
            await _context.TreatmentInvites.AddAsync(invite);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TreatmentInvite invite)
        {
            _context.TreatmentInvites.Update(invite);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TreatmentInviteId id)
        {
            var invite = await GetByIdAsync(id);
            if (invite != null)
            {
                _context.TreatmentInvites.Remove(invite);
                await _context.SaveChangesAsync();
            }
        }
    }
}
