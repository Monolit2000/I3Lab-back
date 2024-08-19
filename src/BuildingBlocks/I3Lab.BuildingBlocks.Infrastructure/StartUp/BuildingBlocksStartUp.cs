using I3Lab.BuildingBlocks.Application;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using I3Lab.BuildingBlocks.Infrastructure.ExecutionContext;
using I3Lab.BuildingBlocks.Infrastructure.Configurations.BlobStorage;
using I3Lab.BuildingBlocks.Infrastructure.Configurations.Cache;

namespace I3Lab.BuildingBlocks.Infrastructure.StartUp
{
    public static class BuildingBlocksStartUp
    {
        public static IServiceCollection AddBuildingBlocksModule(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IExecutionContextAccessor, ExecutionContextAccessor>();

            services.AddBlobStorage(configuration);

            services.AddHealthChecks();

            services.AddCacheAsideService(configuration);

            return services;
        }
    }
}
