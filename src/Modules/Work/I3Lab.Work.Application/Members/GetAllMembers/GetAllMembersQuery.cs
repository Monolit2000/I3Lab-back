using FluentResults;
using I3Lab.Treatments.Application.Contract;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.Members.GetAllMembers
{
    public class GetAllMembersQuery : /*IRequest<Result<List<MemberDto>>>,*/ ICacheableRequest<List<MemberDto>>
    {
        public GetAllMembersQuery()
        {
            
        }


        public string CacheKey => "AllMembers";
        public DistributedCacheEntryOptions Options => throw new NotImplementedException();

    }
}
