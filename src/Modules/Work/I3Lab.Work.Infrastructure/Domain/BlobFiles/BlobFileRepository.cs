using I3Lab.Treatments.Domain.BlobFiles;
using I3Lab.Treatments.Domain.TreatmentStages;
using I3Lab.Treatments.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace I3Lab.Treatments.Infrastructure.Domain.BlobFiles
{
    public class BlobFileRepository : IBlobFileRepository
    {
        private readonly TreatmentContext _context;

        public BlobFileRepository(TreatmentContext context, CancellationToken cancellationToken = default)
        {
            _context = context;
        }

        public async Task<BlobFile> GetByIdAsync(BlobFileId id, CancellationToken cancellationToken = default)
        {
            return await _context.BlobFiles
                .FirstOrDefaultAsync(bf => bf.Id == id);
        }

        public async Task<IEnumerable<BlobFile>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.BlobFiles.ToListAsync();
        }

        public async Task AddAsync(BlobFile blobFile, CancellationToken cancellationToken = default)
        {
            await _context.BlobFiles.AddAsync(blobFile);
        }

        public async Task UpdateAsync(BlobFile blobFile, CancellationToken cancellationToken = default)
        {
            _context.BlobFiles.Update(blobFile);
        }

        public async Task DeleteAsync(BlobFileId id, CancellationToken cancellationToken = default)
        {
            var blobFile = await GetByIdAsync(id);
            if (blobFile != null)
            {
                _context.BlobFiles.Remove(blobFile);
            }
        }

        public async Task<IEnumerable<BlobFile>> GetAllByTreatmentStageIdAsync(TreatmentStageId treatmentStageIdId, CancellationToken cancellationToken = default)
        {
            return await _context.BlobFiles
                .Where(bf => bf.TreatmentStageId == treatmentStageIdId)
                .ToListAsync();
        }

        public async Task<List<BlobFile>> GetAllTypeAndTreatmentStageIdAsync(BlobFileType fileType, TreatmentStageId treatmentStageIdId, CancellationToken cancellationToken = default)
        {
            return await _context.BlobFiles
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
