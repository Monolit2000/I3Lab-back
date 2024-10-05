using I3Lab.Treatments.Domain.TreatmentStages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Domain.TreatmentFils
{
    public interface IBlobFileRepository
    {
        Task<TreatmentFile> GetByIdAsync(BlobFileId id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TreatmentFile>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<TreatmentFile>> GetAllByTreatmentStageIdAsync(TreatmentStageId workId, CancellationToken cancellationToken = default);
        Task<List<TreatmentFile>> GetAllTypeAndTreatmentStageIdAsync(BlobFileType fileType, TreatmentStageId treatmentStageIdId, CancellationToken cancellationToken = default);
        Task AddAsync(TreatmentFile blobFile, CancellationToken cancellationToken = default);
        Task UpdateAsync(TreatmentFile blobFile, CancellationToken cancellationToken = default);
        Task DeleteAsync(BlobFileId id, CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
