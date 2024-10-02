using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace I3Lab.Treatments.Application.Contract
{
    public interface ICacheableRequest<TResponse> : IRequest<TResponse>
    {
        string CacheKey { get; }
        DistributedCacheEntryOptions? Options { get; }
    }

    public interface ICacheableRequest
    {
        string CacheKey { get; }
        DistributedCacheEntryOptions? Options { get; }
    }
}
