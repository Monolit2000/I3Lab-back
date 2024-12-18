﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Administration.Domain.DoctorCreationProposals
{
    public interface IDoctorCreationProposalRepository
    {
        Task<DoctorCreationProposal?> GetByIdAsync(DoctorCreationProposalId id);
        Task<bool> ExistByName(DoctorName doctorName);
        Task AddAsync(DoctorCreationProposal proposal);

        Task UpdateAsync(DoctorCreationProposal proposal);

        Task DeleteAsync(DoctorCreationProposal proposal);

        Task<IEnumerable<DoctorCreationProposal>> GetAllPendingAsync();

        Task<bool> ExistByEmailAsync(Email email);

        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
