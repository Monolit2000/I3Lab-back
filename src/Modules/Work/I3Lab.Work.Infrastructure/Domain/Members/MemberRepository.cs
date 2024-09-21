using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Infrastructure.Domain.Members
{
    public class MemberRepository : IMemberRepository
    {
        private readonly TreatmentContext _context;

        public MemberRepository(TreatmentContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Member> GetMemberByIdAsync(MemberId id)
        {
            var member = await _context.Members
                .FirstOrDefaultAsync(m => m.Id == id);

            return member;
        }

        public async Task<Member> GetByEmailAsync(string email)
        {
            var member = await _context.Members.FirstOrDefaultAsync(m => m.Email == email);

            return member;
        }


        public async Task<bool> IsEmailTakenAsync(string email)
        {
            return await _context.Members.AnyAsync(m => m.Email == email);
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
            var member = await GetMemberByIdAsync(id);
            if (member != null)
            {
                _context.Members.Remove(member);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

