using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Domain.BlobFiles
{
    public interface IBlobFileRepository
    {
        Task<BlobFile> GetByIdAsync(BlobFileId id);
        Task<IEnumerable<BlobFile>> GetAllAsync();
        Task AddAsync(BlobFile blobFile);
        Task UpdateAsync(BlobFile blobFile);
        Task DeleteAsync(BlobFileId id);
    }
}
