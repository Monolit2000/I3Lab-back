﻿using I3Lab.Administration.Domain.DoctorCreationProposals;
using I3Lab.Administration.Infrastructure.Persistence;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace I3Lab.Administration.Infrastructure.Domain.DoctorCreationProposals
{
    public class DoctorCreationProposalRepository : IDoctorCreationProposalRepository
    {
        private readonly AdministrationContext _context;

        public DoctorCreationProposalRepository(AdministrationContext context)
        {
            _context = context;
        }

        public async Task<DoctorCreationProposal?> GetByIdAsync(DoctorCreationProposalId id)
        {
            return await _context.DoctorCreationProposals
                .FirstOrDefaultAsync(p => p.Id == id);
        }


        public async Task<bool> ExistByName(DoctorName doctorName)
        {
            return await _context.DoctorCreationProposals.AnyAsync(d => d.Name == doctorName);
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
                .Where(p => p.ConfirmationStatus == DoctorCreationProposalStatus.Validation)
                .ToListAsync();
        }

        public async Task<bool> ExistByEmailAsync(Email email)
        {
            var exist = await _context.DoctorCreationProposals.AnyAsync(x => x.Email == email);

            if (exist is false)
                return exist;

            return exist;
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
