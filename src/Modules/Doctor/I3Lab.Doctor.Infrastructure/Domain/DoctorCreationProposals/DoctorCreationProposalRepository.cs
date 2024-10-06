using I3Lab.Doctors.Domain.DoctorCreationProposals;
using I3Lab.Doctors.Domain.Doctors;
using I3Lab.Doctors.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace I3Lab.Doctors.Infrastructure.Domain.DoctorCreationProposals
{
    public class DoctorCreationProposalRepository : IDoctorCreationProposalRepository
    {
        private readonly DoctorContext _context;

        public DoctorCreationProposalRepository(DoctorContext context)
        {
            _context = context;
        }

        public async Task<DoctorCreationProposal> GetByIdAsync(DoctorCreationProposalId id, CancellationToken cancellationToken = default)
        {
            return await _context.DoctorCreationProposals
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public async Task AddAsync(DoctorCreationProposal proposal, CancellationToken cancellationToken = default)
        {
            await _context.DoctorCreationProposals.AddAsync(proposal, cancellationToken);
        }

        public async Task UpdateAsync(DoctorCreationProposal proposal, CancellationToken cancellationToken = default)
        {
            _context.DoctorCreationProposals.Update(proposal);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(DoctorCreationProposal proposal, CancellationToken cancellationToken = default)
        {
            _context.DoctorCreationProposals.Remove(proposal);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<DoctorCreationProposal>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.DoctorCreationProposals
                .Where(p => p.ConfirmationStatus == ConfirmationStatus.Validation)
                .ToListAsync(cancellationToken);
        }


        public async Task<IEnumerable<DoctorCreationProposal>> GetAllByStatusAsync(ConfirmationStatus status, CancellationToken cancellationToken = default)
        {
            return await _context.DoctorCreationProposals
                .Where(p => p.ConfirmationStatus == status)
                .ToListAsync(cancellationToken);
        }



        public async Task<bool> ExistByEmailAsync(Email email, CancellationToken cancellationToken = default)
        {
            var exist = await _context.DoctorCreationProposals
                .AnyAsync(x => x.Email.Value == email.Value, cancellationToken);

            return exist;
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
