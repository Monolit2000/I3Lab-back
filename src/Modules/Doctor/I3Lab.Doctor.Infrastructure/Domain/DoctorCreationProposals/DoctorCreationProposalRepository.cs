using I3Lab.Doctors.Domain.DoctorCreationProposals;
using I3Lab.Doctors.Domain.Doctors;
using I3Lab.Doctors.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Doctors.Infrastructure.Domain.DoctorCreationProposals
{
    public class DoctorCreationProposalRepository : IDoctorCreationProposalRepository
    {
        private readonly DoctorContext _context;

        public DoctorCreationProposalRepository(DoctorContext context)
        {
            _context = context;
        }

        public async Task<DoctorCreationProposal> GetByIdAsync(DoctorCreationProposalId id)
        {
            return await _context.DoctorCreationProposals
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(DoctorCreationProposal proposal)
        {
            await _context.DoctorCreationProposals.AddAsync(proposal);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DoctorCreationProposal proposal)
        {
            _context.DoctorCreationProposals.Update(proposal);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(DoctorCreationProposal proposal)
        {
            _context.DoctorCreationProposals.Remove(proposal);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DoctorCreationProposal>> GetAllPendingAsync()
        {
            return await _context.DoctorCreationProposals
                .Where(p => p.ConfirmationStatus == ConfirmationStatus.Validation)
                .ToListAsync();
        }

        public async Task<bool> ExistByEmailAsync(Email email)
        {
            var exist = await _context.DoctorCreationProposals.AnyAsync(x => x.Email.Value == email.Value);

            return exist;
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
