using FluentResults;
using I3Lab.Treatments.Application.Contract;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;


namespace I3Lab.Treatments.Application.Members.GetAllMembers
{
    public class GetAllMembersQuery : IRequest<List<MemberDto>>, ICacheableRequest  
    {
        public GetAllMembersQuery()
        {
            
        }

        public string CacheKey => "all-members";
        public DistributedCacheEntryOptions Options => throw new NotImplementedException();

    }
}
