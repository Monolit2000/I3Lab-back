using I3Lab.BuildingBlocks.Application.Cache;
using I3Lab.BuildingBlocks.Infrastructure.Cache;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace I3Lab.BuildingBlocks.Infrastructure.Configurations.Cache
{
    public static class CacheDIConfiguration
    {
        public static IServiceCollection AddCacheAsideService(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDistributedMemoryCache();

            services.AddMemoryCache();

            services.AddSingleton<ICacheService, CacheService>();
            services.AddSingleton<IInMemoryCacheService, InMemoryCacheService>();
            services.AddSingleton<IDistributedCacheService, DistributedCacheService>();

            return services;
        }
    }
}
