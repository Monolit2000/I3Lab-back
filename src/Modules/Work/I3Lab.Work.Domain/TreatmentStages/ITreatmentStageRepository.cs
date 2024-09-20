using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments;

namespace I3Lab.Treatments.Domain.TreatmentStages
{
    public interface ITreatmentStageRepository
    {
        Task<TreatmentStage> GetByIdAsync(TreatmentStageId id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TreatmentStage>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<TreatmentStage>> GetAllByMemberIdAsync(MemberId id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TreatmentStage>> GetAllByTreatmentIdAsync(TreatmentId id, CancellationToken cancellationToken = default);
        Task AddAsync(TreatmentStage work, CancellationToken cancellationToken = default);
        Task UpdateAsync(TreatmentStage work, CancellationToken cancellationToken = default);
        Task DeleteAsync(TreatmentStageId id, CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
