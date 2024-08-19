using I3Lab.Works.Application.BlobFiles.AddBlobFile;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.BuildingBlocks.Infrastructure.Configurations.Cache
{
    public static class CacheDIConfiguration
    {
        public static IServiceCollection AddCacheAsideService(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDistributedMemoryCache();

            return services;
        }
    }
}
