using I3Lab.Treatments.Domain.TreatmentFiles;
using I3Lab.Treatments.Domain.TreatmentStages;
using I3Lab.Treatments.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace I3Lab.Treatments.Infrastructure.Domain.TreatmentFiles
{
    public class TreatmentFileRepository : ITreatmentFileRepository
    {
        private readonly TreatmentContext _context;

        public TreatmentFileRepository(TreatmentContext context, CancellationToken cancellationToken = default)
        {
            _context = context;
        }

        public async Task<TreatmentFile> GetByIdAsync(TreatmentFileId id, CancellationToken cancellationToken = default)
        {
            return await _context.TreatmentFiles
                .FirstOrDefaultAsync(bf => bf.Id == id);
        }

        public async Task<IEnumerable<TreatmentFile>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.TreatmentFiles.ToListAsync();
        }

        public async Task AddAsync(TreatmentFile blobFile, CancellationToken cancellationToken = default)
        {
            await _context.TreatmentFiles.AddAsync(blobFile);
        }

        public async Task UpdateAsync(TreatmentFile blobFile, CancellationToken cancellationToken = default)
        {
            _context.TreatmentFiles.Update(blobFile);
        }

        public async Task DeleteAsync(TreatmentFileId id, CancellationToken cancellationToken = default)
        {
            var blobFile = await GetByIdAsync(id);
            if (blobFile != null)
            {
                _context.TreatmentFiles.Remove(blobFile);
            }
        }

        public async Task<IEnumerable<TreatmentFile>> GetAllByTreatmentStageIdAsync(TreatmentStageId treatmentStageIdId, CancellationToken cancellationToken = default)
        {
            return await _context.TreatmentFiles
                .Where(bf => bf.TreatmentStageId == treatmentStageIdId)
                .ToListAsync();
        }

        public async Task<List<TreatmentFile>> GetAllTypeAndTreatmentStageIdAsync(BlobFileType fileType, TreatmentStageId treatmentStageIdId, CancellationToken cancellationToken = default)
        {
            return await _context.TreatmentFiles
                .Where(bf => bf.TreatmentStageId == treatmentStageIdId)
                .Where(bf => bf.FileType == fileType)
                .ToListAsync();
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync();
        }
    }
}
