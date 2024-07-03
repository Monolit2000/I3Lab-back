using Azure.Storage.Blobs;
using I3Lab.BuildingBlocks.Application.BlobStorage;
using I3Lab.BuildingBlocks.Infrastructure.BlobStorage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.BuildingBlocks.Infrastructure.StartUp
{
    public static class BuildingBlocksStartUp
    {
        public static IServiceCollection AddBuildingBlocksModule(
     this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("");

            services.AddSingleton<IBlobService, BlobService>();

            services.AddSingleton(_ => new BlobServiceClient(configuration.GetConnectionString("BlobStorage")));
            return services;
        }
    }
}
