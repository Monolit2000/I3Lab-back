using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Domain.TreatmentStages;

namespace I3Lab.Treatments.Domain.TreatmentStageChats
{
    public interface ITreatmentStageChatRepository
    {
        Task<TreatmentStageChat> GetByIdAsync(TreatmentStageChatId id, CancellationToken cancellationToken = default);
        Task<TreatmentStageChat> GetByTreatmentStageIdAsync(TreatmentStageId workId, CancellationToken cancellationToken = default);

        Task<List<TreatmentStageChat>> GetAllByTreatmentStageId(TreatmentStageId treatmentStageId, CancellationToken cancellationToken = default);
        Task<List<TreatmentStageChat>> GetAllByTreatmentIdAsync(TreatmentId treatmentId, CancellationToken cancellationToken = default);

        Task AddAsync(TreatmentStageChat workChat, CancellationToken cancellationToken = default);
        Task UpdateAsync(TreatmentStageChat workChat, CancellationToken cancellationToken = default);
        Task RemoveAsync(TreatmentStageChat workChat, CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
