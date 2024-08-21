using I3Lab.Works.Domain.WorkDirectorys;
using I3Lab.Works.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace I3Lab.Works.Infrastructure.Domain.WorkDirectorys
{
    public class WorkDirectoryRepository /*: IWorkDirectoryRepository*/
    {
        private readonly WorkContext _context;

        //public WorkDirectoryRepository(WorkContext context)
        //{
        //    _context = context;
        //}

        //public async Task<WorkDirectory> GetMByIdAsync(WorkDirectoryId id)
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

        //public async Task DeleteAsync(WorkDirectoryId id)
        //{
        //    var workDirectory = await GetMByIdAsync(id);
        //    if (workDirectory != null)
        //    {
        //        _context.WorkDirectories.Remove(workDirectory);
        //        await _context.SaveChangesAsync();
        //    }
        //}
    }
}
