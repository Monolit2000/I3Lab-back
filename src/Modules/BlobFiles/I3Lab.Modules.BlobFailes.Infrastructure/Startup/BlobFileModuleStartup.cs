
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using I3Lab.Modules.BlobFailes.Infrastructure.Configurations.Application;
using I3Lab.Modules.BlobFailes.Infrastructure.Configurations.Persistence;
using I3Lab.Modules.BlobFailes.Infrastructure.Configurations.EventBus;

namespace I3Lab.Modules.BlobFailes.Infrastructure.Startup
{
    public static class BlobFileModuleStartup
    {
        public static IServiceCollection AddBlobFileModule(
      this IServiceCollection services, IConfiguration configuration)
        {

            services.AddApplicationServices(configuration);

            services.AddPersistenceServices(configuration);

            services.AddMassTransitEventBus(configuration);

            //QuartzStartup.Initialize();

            return services;
        }
    }
}
