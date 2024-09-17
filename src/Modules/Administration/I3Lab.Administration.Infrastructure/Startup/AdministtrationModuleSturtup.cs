using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using I3Lab.Administration.Infrastructure.Configurations.Persistence;
using I3Lab.Administration.Infrastructure.Configurations.EventBus;
using I3Lab.Administration.Infrastructure.Configurations.Application;

namespace I3Lab.Administration.Infrastructure.StartUp
{
    public static class AdministtrationModuleSturtup
    {
        public static IServiceCollection AddAdministrationModule(
             this IServiceCollection services, IConfiguration configuration)
        {

            services.AddApplicationServices(configuration);

            services.AddPersistenceServices(configuration);

            services.AddMassTransitEventBus(configuration);

            return services;
        }
    }
}
