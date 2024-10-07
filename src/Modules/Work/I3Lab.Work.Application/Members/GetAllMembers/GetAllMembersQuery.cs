using MediatR;
using I3Lab.Treatments.Application.Contract;
using Microsoft.Extensions.Caching.Distributed;
using I3Lab.Treatments.Application.Configuration.CaheKeys.Members;

namespace I3Lab.Treatments.Application.Members.GetAllMembers
{
    public class GetAllMembersQuery : IRequest<List<MemberDto>>, ICacheableRequest  
    {
        public GetAllMembersQuery()
        {
        }

        public string CacheKey => MembersCaheKeys.Members;
        public DistributedCacheEntryOptions Options => throw new NotImplementedException();
    }
}
