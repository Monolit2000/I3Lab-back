using I3Lab.Works.Domain.WorkChats;
using I3Lab.Works.Domain.Works;
using I3Lab.Works.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;
using System.Threading;

namespace I3Lab.Works.Infrastructure.Domain.WorkChats
{
    public class WorkChatRepository : IWorkChatRepository
    {
        private readonly WorkContext _context;

        public WorkChatRepository(WorkContext context)
        {
            _context = context;
        }

        public async Task<WorkChat> GetByIdAsync(WorkChatId id, CancellationToken cancellationToken = default)
        {
            return await _context.WorkChats
                .Include(wc => wc.Messages)
                .Include(wc => wc.ChatMembers)
                .FirstOrDefaultAsync(wc => wc.Id == id, cancellationToken);
        }

        public async Task<WorkChat> GetByWorkIdAsync(WorkId workId, CancellationToken cancellationToken = default)
        {
            return await _context.WorkChats
                .Include(wc => wc.Messages)
                .Include(wc => wc.ChatMembers)
                .FirstOrDefaultAsync(wc => wc.WorkId == workId, cancellationToken);
              
        }

        public async Task AddAsync(WorkChat workChat, CancellationToken cancellationToken = default)
        {
            await _context.WorkChats.AddAsync(workChat, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(WorkChat workChat, CancellationToken cancellationToken = default)
        {
            _context.WorkChats.Update(workChat);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task RemoveAsync(WorkChat workChat, CancellationToken cancellationToken = default)
        {
            _context.WorkChats.Remove(workChat);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync();
        }
    }
}
