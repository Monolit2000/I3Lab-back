using FluentResults;
using I3Lab.Treatments.Application.Contract;
using Microsoft.Extensions.Caching.Distributed;

namespace I3Lab.Treatments.Application.Treatments.GetAllTreatment
{
    public class GetAllTreatmentQuery : /*IRequest<Result<List<TreatmentDto>>>,*/ ICacheableRequest<Result<List<TreatmentDto>>>
    {
        public GetAllTreatmentQuery()
        {
            
        }

        public string CacheKey => "all-treatments";

        public DistributedCacheEntryOptions Options => throw new NotImplementedException();
    }
}
