using I3Lab.Treatments.Domain.WorkDirectorys;
using I3Lab.Treatments.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace I3Lab.Treatments.Infrastructure.Domain.WorkDirectorys
{
    public class WorkDirectoryRepository /*: IWorkDirectoryRepository*/
    {
        private readonly TreatmentContext _context;

        //public WorkDirectoryRepository(TreatmentContext context)
        //{
        //    _context = context;
        //}

        //public async Task<WorkDirectory> GetAsync(WorkDirectoryId id)
        //{
        //    var workDirectory = await _context.WorkDirectories
        //        .Include(wd => wd.Files3Ds)
        //        .Include(wd => wd.OtherFiles)
        //        .FirstOrDefaultAsync(wd => wd.Id == id);

        //    return workDirectory;
        //}

        //public async Task AddAsync(WorkDirectory workDirectory)
        //{
        //    await _context.WorkDirectories.AddAsync(workDirectory);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task UpdateAsync(WorkDirectory workDirectory)
        //{
        //    _context.WorkDirectories.Update(workDirectory);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task DeleteByIdIfExistAsync(WorkDirectoryId id)
        //{
        //    var workDirectory = await GetAsync(id);
        //    if (workDirectory != null)
        //    {
        //        _context.WorkDirectories.Remove(workDirectory);
        //        await _context.SaveChangesAsync();
        //    }
        //}
    }
}
