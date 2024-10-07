using I3Lab.Clinics.Domain.Clinics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Clinics.Domain.ClinicCreationProposals
{
    public interface IClinicCreationProposalRepository
    {
        Task<ClinicCreationProposal> GetByIdAsync(ClinicCreationProposalId id, CancellationToken cancellationToken = default);
        Task AddAsync(ClinicCreationProposal proposal, CancellationToken cancellationToken = default);
        Task UpdateAsync(ClinicCreationProposal proposal, CancellationToken cancellationToken = default);
        Task DeleteAsync(ClinicCreationProposal proposal, CancellationToken cancellationToken = default);
        Task<IEnumerable<ClinicCreationProposal>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<ClinicCreationProposal>> GetAllByStatusAsync(ConfirmationStatus status, CancellationToken cancellationToken = default);
        //Task<bool> ExistByEmailAsync(Email email, CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
