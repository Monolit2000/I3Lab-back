using I3Lab.Treatments.Domain.BlobFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = I3Lab.Treatments.Domain.BlobFiles.BlobFile;

namespace I3Lab.Treatments.Domain.WorkDirectorys
{
    public interface IWorkDirectoryRepository
    {
        Task<WorkDirectory> GetByIdAsync(WorkDirectoryId id);
        Task AddAsync(WorkDirectory workDirectory);
        Task UpdateAsync(WorkDirectory workDirectory);
        Task DeleteAsync(WorkDirectoryId id);
    }
}
