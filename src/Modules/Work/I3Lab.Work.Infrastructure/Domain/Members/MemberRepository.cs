using I3Lab.Works.Domain.Members;
using I3Lab.Works.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Infrastructure.Domain.Members
{
    public class MemberRepository : IMemberRepository
    {
        private readonly WorkContext _context;

        public MemberRepository(WorkContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Member> GetByIdAsync(MemberId id)
        {
            var member = await _context.Members
                .FirstOrDefaultAsync(m => m.Id == id);

            return member;
        }

        public async Task<IEnumerable<Member>> GetAllAsync()
        {
            return await _context.Members.ToListAsync();
        }

        public async Task AddAsync(Member member)
        {
            await _context.Members.AddAsync(member);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Member member)
        {
            _context.Members.Update(member);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(MemberId id)
        {
            var member = await GetByIdAsync(id);
            if (member != null)
            {
                _context.Members.Remove(member);
                await _context.SaveChangesAsync();
            }
        }
    }
}

