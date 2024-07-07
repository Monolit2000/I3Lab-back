using I3Lab.Works.Domain.BlobFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = I3Lab.Works.Domain.BlobFiles.BlobFile;

namespace I3Lab.Works.Domain.WorkDirectorys
{
    public interface IWorkDirectoryRepository
    {
        Task<WorkDirectory> GetByIdAsync(WorkDirectoryId id);
        Task AddAsync(WorkDirectory workDirectory);
        Task UpdateAsync(WorkDirectory workDirectory);
        Task DeleteAsync(WorkDirectoryId id);
    }
}
