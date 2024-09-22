using Microsoft.EntityFrameworkCore;
using I3Lab.Modules.BlobFailes.Domain.BlobFiles;
using I3Lab.Modules.BlobFailes.Infrastructure.Persistence;

namespace I3Lab.Modules.BlobFailes.Infrastructure.Domain.BlobFiles
{
    public class BlobFileRepository : IBlobFileRepository
    {
        private readonly BlobFileContext _context;

        public BlobFileRepository(BlobFileContext context, CancellationToken cancellationToken = default)
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
        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync();
        }
    }
}
