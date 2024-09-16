using Microsoft.Extensions.Caching.Distributed;

namespace I3Lab.BuildingBlocks.Application.Cache
{
    public interface ICacheService
    {
        Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default)
            where T : class;

        Task SetAsync<T>(string key, T value, DistributedCacheEntryOptions options = null, CancellationToken cancellationToken = default);

        Task RemoveAsync(string key, CancellationToken cancellationToken = default);

        Task RemuveByPrefixAsync(string prefix, CancellationToken cancellationToken = default);
    }
}
