using I3Lab.Works.Domain.BlobFiles;
using I3Lab.Works.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Infrastructure.Domain.BlobFiles
{
    public class BlobFileRepository : IBlobFileRepository
    {
        private readonly WorkDbContext _context;

        public BlobFileRepository(WorkDbContext context)
        {
            _context = context;
        }

        public async Task<BlobFile> GetByIdAsync(BlobFileId id)
        {
            var file = await _context.BlobFiles
                .FirstOrDefaultAsync(bf => bf.Id == id);

            return file;
        }

        public async Task<IEnumerable<BlobFile>> GetAllAsync()
        {
            return await _context.BlobFiles.ToListAsync();
        }

        public async Task AddAsync(BlobFile blobFile)
        {
            await _context.BlobFiles.AddAsync(blobFile);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BlobFile blobFile)
        {
            _context.BlobFiles.Update(blobFile);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(BlobFileId id)
        {
            var blobFile = await GetByIdAsync(id);
            if (blobFile != null)
            {
                _context.BlobFiles.Remove(blobFile);
                await _context.SaveChangesAsync();
            }
        }
    }
}
