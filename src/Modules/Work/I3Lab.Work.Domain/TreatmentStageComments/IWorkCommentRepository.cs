using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.TreatmentStages;

namespace I3Lab.Treatments.Domain.TreatmentStageComments
{
    public interface IWorkCommentRepository
    {
        Task<TreatmentStageComment> GetByIdAsync(TreatmentStageCommentId id);
        Task<IEnumerable<TreatmentStageComment>> GetAllAsync();
        Task<IEnumerable<TreatmentStageComment>> GetAllByWorkIdAsync(TreatmentStageId workId);
        Task<TreatmentStageComment> GetByMemberIdAsync(MemberId memberId);
        Task AddAsync(TreatmentStageComment workComment);
        Task UpdateAsync(TreatmentStageComment workComment);
        Task DeleteAsync(TreatmentStageCommentId id);
    }
}
