using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Domain.Members
{
    public interface IMemberRepository
    {
        Task<List<Member>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Member> GetMemberByIdAsync(MemberId id, CancellationToken cancellationToken = default);
        Task<Member> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
        Task<bool> IsEmailTakenAsync(string email, CancellationToken cancellationToken = default);
        Task AddAsync(Member member, CancellationToken cancellationToken = default);
        Task UpdateAsync(Member member, CancellationToken cancellationToken = default);
        Task DeleteAsync(MemberId id, CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
