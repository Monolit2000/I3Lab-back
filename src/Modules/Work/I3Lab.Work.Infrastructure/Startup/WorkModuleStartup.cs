using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using I3Lab.Treatments.Infrastructure.Configurations.EventBus;
using I3Lab.Treatments.Infrastructure.Configurations.Persistence;
using I3Lab.Treatments.Infrastructure.Configurations.Application;

namespace I3Lab.Treatments.Infrastructure.Startup
{
    public static class WorkModuleStartup
    {
        public static IServiceCollection AddTreatmentModule(
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
