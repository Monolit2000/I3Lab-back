using I3Lab.BuildingBlocks.Application.Cache;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Text.Json;



namespace I3Lab.BuildingBlocks.Infrastructure.Cache
{
    public class CacheService : ICacheService
    {
        private static readonly ConcurrentDictionary<string, bool> CacheKeys = [];

        private readonly IDistributedCache _distributedCache;

        public CacheService(IDistributedCache cache)
        {
            _distributedCache = cache;
        }
        public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default) 
            where T : class
        {
            var cacheValue = await _distributedCache.GetStringAsync(
                key, 
                cancellationToken);

            if (string.IsNullOrEmpty(cacheValue))
                return null;

            return JsonConvert.DeserializeObject<T>(cacheValue);
        }

        public async Task SetAsync<T>(string key, T value, DistributedCacheEntryOptions options = null, CancellationToken cancellationToken = default)
        {
            string cacheValue = JsonConvert.SerializeObject(value);

            await _distributedCache.SetStringAsync(key, cacheValue, options ?? new DistributedCacheEntryOptions(), cancellationToken);

            CacheKeys.TryAdd(key, false);
        }


        public async Task RemoveAsync(string key, CancellationToken cancellationToken = default)
        {
            await _distributedCache.RemoveAsync(key, cancellationToken);

            CacheKeys.TryRemove(key, out _);
        }

        public async Task RemuveByPrefixAsync(string prefix, CancellationToken cancellationToken = default)
        {
            IEnumerable<Task> tasks = CacheKeys
                .Keys
                .Where(k => k.StartsWith(prefix))
                .Select(k => RemoveAsync(k, cancellationToken));

            await Task.WhenAll(tasks);
        }
    }
}
