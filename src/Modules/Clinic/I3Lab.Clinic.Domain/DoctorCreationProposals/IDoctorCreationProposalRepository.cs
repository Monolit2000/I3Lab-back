using I3Lab.Clinics.Domain.Doctors;

namespace I3Lab.Clinics.Domain.DoctorCreationProposals
{
    public interface IDoctorCreationProposalRepository
    {
        Task<IEnumerable<DoctorCreationProposal>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<DoctorCreationProposal> GetByIdAsync(DoctorCreationProposalId id, CancellationToken cancellationToken = default);
        Task<IEnumerable<DoctorCreationProposal>> GetAllByStatusAsync(ConfirmationStatus status, CancellationToken cancellationToken = default);
        Task AddAsync(DoctorCreationProposal proposal, CancellationToken cancellationToken = default);
        Task UpdateAsync(DoctorCreationProposal proposal, CancellationToken cancellationToken = default);
        Task DeleteAsync(DoctorCreationProposal proposal, CancellationToken cancellationToken = default);
        Task<bool> ExistByEmailAsync(Email email, CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
