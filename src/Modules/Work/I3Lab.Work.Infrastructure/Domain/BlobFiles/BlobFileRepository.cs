using I3Lab.Works.Domain.BlobFiles;
using I3Lab.Works.Domain.Works;
using I3Lab.Works.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace I3Lab.Works.Infrastructure.Domain.BlobFiles
{
    public class BlobFileRepository : IBlobFileRepository
    {
        private readonly WorkContext _context;

        public BlobFileRepository(WorkContext context)
        {
            _context = context;
        }

        public async Task<BlobFile?> GetByIdAsync(BlobFileId id)
        {
            return await _context.BlobFiles
                .FirstOrDefaultAsync(bf => bf.Id == id);
        }

        public async Task<IEnumerable<BlobFile>> GetAllAsync()
        {
            return await _context.BlobFiles.ToListAsync();
        }

        public async Task AddAsync(BlobFile blobFile)
        {
            await _context.BlobFiles.AddAsync(blobFile);
            await SaveChangesAsync();
        }

        public async Task UpdateAsync(BlobFile blobFile)
        {
            _context.BlobFiles.Update(blobFile);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(BlobFileId id)
        {
            var blobFile = await GetByIdAsync(id);
            if (blobFile != null)
            {
                _context.BlobFiles.Remove(blobFile);
                await SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<BlobFile>> GetAllByWorkIdAsync(WorkId workId)
        {
            return await _context.BlobFiles
                .Where(bf => bf.WorkId == workId)
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
