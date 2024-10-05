using FluentResults;
using I3Lab.Treatments.Application.Contract;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.Treatments.GetAllTreatmentsByUserId
{
    public class GetAllTreatmentsByMemberIdQuery : IRequest<Result<List<TreatmentDto>>>, ICacheableRequest
    {
        public Guid UserId { get; set; }

        public string CacheKey => $"allTreatmentsByMember{UserId}";

        public DistributedCacheEntryOptions Options => throw new NotImplementedException();
    }
}
