using I3Lab.BuildingBlocks.Application.Cache;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace I3Lab.BuildingBlocks.Infrastructure.Cache
{
    public static class InMemoryCacheAside
    {
        private static readonly MemoryCacheEntryOptions Default = new()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
        };

        private static readonly TimeSpan DefaultExpiration = TimeSpan.FromSeconds(30);

        public static async Task<T?> GetOrCreateAsync<T>(
            this IInMemoryCacheService cacheService,
            string key,
            Func<CancellationToken, Task<T>> factory,
            TimeSpan? expiration = null,
            CancellationToken cancellationToken = default)
        {
            var cacheValue = await cacheService.GetAsync<T>(key);
            if (cacheValue is not null)
            {
                return cacheValue;
            }

            var result = await factory(cancellationToken);

            if (result is null)
                return default;

            await cacheService.SetAsync(key, result, expiration ?? DefaultExpiration);

            return result;
        }
    }
}
