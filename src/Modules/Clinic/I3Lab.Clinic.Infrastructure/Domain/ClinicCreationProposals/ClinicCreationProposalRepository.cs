using I3Lab.Clinics.Domain.ClinicCreationProposals;
using I3Lab.Clinics.Domain.Clinics;
using I3Lab.Clinics.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace I3Lab.Clinics.Infrastructure.Domain.Clinics
{
    public class ClinicCreationProposalRepository : IClinicCreationProposalRepository
    {
        private readonly ClinicContext _context;

        public ClinicCreationProposalRepository(ClinicContext context)
        {
            _context = context;
        }

        public async Task<ClinicCreationProposal> GetByIdAsync(ClinicCreationProposalId id, CancellationToken cancellationToken = default)
        {
            return await _context.ClinicCreationProposals
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public async Task AddAsync(ClinicCreationProposal proposal, CancellationToken cancellationToken = default)
        {
            await _context.ClinicCreationProposals.AddAsync(proposal, cancellationToken);
        }

        public async Task UpdateAsync(ClinicCreationProposal proposal, CancellationToken cancellationToken = default)
        {
            _context.ClinicCreationProposals.Update(proposal);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(ClinicCreationProposal proposal, CancellationToken cancellationToken = default)
        {
            _context.ClinicCreationProposals.Remove(proposal);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<ClinicCreationProposal>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.ClinicCreationProposals
                .Where(p => p.ConfirmationStatus == ConfirmationStatus.Validation)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<ClinicCreationProposal>> GetAllByStatusAsync(ConfirmationStatus status, CancellationToken cancellationToken = default)
        {
            return await _context.ClinicCreationProposals
                .Where(p => p.ConfirmationStatus == status)
                .ToListAsync(cancellationToken);
        }

        //public async Task<bool> ExistByEmailAsync(Email email, CancellationToken cancellationToken = default)
        //{
        //    var exist = await _context.ClinicCreationProposals
        //        .AnyAsync(x => x.Email.Value == email.Value, cancellationToken);

        //    return exist;
        //}

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
