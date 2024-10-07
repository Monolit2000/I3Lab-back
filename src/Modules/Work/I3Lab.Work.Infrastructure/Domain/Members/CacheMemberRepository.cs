using I3Lab.BuildingBlocks.Application.Cache;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Infrastructure.Configurations.CaheKeys.Members;
using Microsoft.Extensions.Caching.Memory;

namespace I3Lab.Treatments.Infrastructure.Domain.Members
{
    public class CacheMemberRepository(
        IMemberRepository decorated,
        IInMemoryCacheService inMemoryCacheService,
        IMemoryCache memoryCache) : IMemberRepository
    {
        public async Task<List<Member>> GetAllAsync(CancellationToken cancellationToken = default)
        {

            return await memoryCache.GetOrCreateAsync(
                MembersCaheKeys.Members, 
                entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(1));
                return decorated.GetAllAsync(cancellationToken);
            });

        }

        public Task<Member> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return decorated.GetByEmailAsync(email, cancellationToken);
        }

        public Task<Member> GetMemberByIdAsync(MemberId id, CancellationToken cancellationToken = default)
        {
            return decorated.GetMemberByIdAsync(id, cancellationToken);
        }

        public Task AddAsync(Member member, CancellationToken cancellationToken = default)
        {
            return decorated.AddAsync(member, cancellationToken);
        }

        public Task DeleteAsync(MemberId id, CancellationToken cancellationToken = default)
        {
            return decorated.DeleteAsync(id, cancellationToken);
        }

        public Task<bool> IsEmailTakenAsync(string email, CancellationToken cancellationToken = default)
        {
            return decorated.IsEmailTakenAsync(email, cancellationToken);
        }

        public Task UpdateAsync(Member member, CancellationToken cancellationToken = default)
        {
            return decorated.UpdateAsync(member, cancellationToken);
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return decorated.SaveChangesAsync(cancellationToken);
        }
    }
}
