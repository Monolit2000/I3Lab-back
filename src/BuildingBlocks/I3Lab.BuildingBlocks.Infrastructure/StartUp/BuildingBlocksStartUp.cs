using Azure.Storage.Blobs;
using I3Lab.BuildingBlocks.Application;
using I3Lab.BuildingBlocks.Application.BlobStorage;
using I3Lab.BuildingBlocks.Infrastructure.BlobStorage;
using I3Lab.BuildingBlocks.Infrastructure.ExecutionContext;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace I3Lab.BuildingBlocks.Infrastructure.StartUp
{
    public static class BuildingBlocksStartUp
    {
        public static IServiceCollection AddBuildingBlocksModule(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IBlobService, BlobService>();

            services.AddSingleton(_ => new BlobServiceClient(configuration.GetConnectionString("BlobStorage")));

            services.AddSingleton<IExecutionContextAccessor, ExecutionContextAccessor>();

            return services;
        }
    }
}
