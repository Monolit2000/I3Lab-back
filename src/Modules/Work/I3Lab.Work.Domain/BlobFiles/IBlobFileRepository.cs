using I3Lab.Treatments.Domain.TreatmentStages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Domain.BlobFiles
{
    public interface IBlobFileRepository
    {
        Task<BlobFile> GetByIdAsync(BlobFileId id, CancellationToken cancellationToken = default);
        Task<IEnumerable<BlobFile>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<BlobFile>> GetAllByTreatmentStageIdAsync(TreatmentStageId workId, CancellationToken cancellationToken = default);
        Task<List<BlobFile>> GetAllTypeAndTreatmentStageIdAsync(BlobFileType fileType, TreatmentStageId treatmentStageIdId, CancellationToken cancellationToken = default);
        Task AddAsync(BlobFile blobFile, CancellationToken cancellationToken = default);
        Task UpdateAsync(BlobFile blobFile, CancellationToken cancellationToken = default);
        Task DeleteAsync(BlobFileId id, CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
