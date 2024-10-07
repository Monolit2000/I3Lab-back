using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace I3Lab.Treatments.Infrastructure.Domain.Members
{
    public class MemberRepository : IMemberRepository
    {
        private readonly TreatmentContext _context;

        public MemberRepository(TreatmentContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Member>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Members.ToListAsync(cancellationToken);
        }

        public async Task<Member> GetMemberByIdAsync(MemberId id, CancellationToken cancellationToken = default)
        {
            return await _context.Members
                .FirstOrDefaultAsync(m => m.Id == id, cancellationToken);
        }

        public async Task<Member> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await _context.Members.FirstOrDefaultAsync(m => m.Email == email, cancellationToken);
        }

        public async Task<bool> IsEmailTakenAsync(string email, CancellationToken cancellationToken = default)
        {
            return await _context.Members.AnyAsync(m => m.Email == email, cancellationToken);
        }

        public async Task AddAsync(Member member, CancellationToken cancellationToken = default)
        {
            await _context.Members.AddAsync(member, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Member member, CancellationToken cancellationToken = default)
        {
            _context.Members.Update(member);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(MemberId id, CancellationToken cancellationToken = default)
        {
            var member = await GetMemberByIdAsync(id, cancellationToken);
            if (member != null)
            {
                _context.Members.Remove(member);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
