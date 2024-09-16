using System.Text.Json;
using I3Lab.BuildingBlocks.Application.Cache;
using Microsoft.Extensions.Caching.Distributed;

namespace I3Lab.BuildingBlocks.Infrastructure.Cache
{
    public static class CacheAside
    {
        private static readonly DistributedCacheEntryOptions Default = new()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
        };

        public static async Task<T?> GetOrCreateAsync<T>(
            this IDistributedCache cache,
            string key,
            Func<CancellationToken, Task<T>> factory,
            DistributedCacheEntryOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            var caheValue = await cache.GetStringAsync(key, cancellationToken);

            T? value;
            if (!string.IsNullOrWhiteSpace(caheValue))
            {
                value = JsonSerializer.Deserialize<T>(caheValue, new JsonSerializerOptions { IncludeFields = true });

                if (value is not null)
                {
                    return value;
                }

            }

            value = await factory(cancellationToken);

            if (value is null)
                return default;

            await cache.SetStringAsync(key, JsonSerializer.Serialize(value), options ?? Default, cancellationToken);

            return value;
        }

        public static async Task<T?> GetOrCreateAsync<T>(
          this ICacheService cacheService,
          string key,
          Func<CancellationToken, Task<T>> factory,
          DistributedCacheEntryOptions? options = null,
          CancellationToken cancellationToken = default)
          where T : class
        {
            var cacheValue = await cacheService.GetAsync<T>(key, cancellationToken);

            if (cacheValue is not null)
                return cacheValue;

            var value = await factory(cancellationToken);
            
            if (value is null)
                return null;

            await cacheService.SetAsync(key, value, options ?? Default, cancellationToken);

            return value;
        }
    }
}
