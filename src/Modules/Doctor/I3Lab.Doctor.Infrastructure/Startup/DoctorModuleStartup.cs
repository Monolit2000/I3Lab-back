using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using I3Lab.Doctors.Infrastructure.Configurations.Application;
using I3Lab.Doctors.Infrastructure.Configurations.Persistence;
using I3Lab.Doctors.Infrastructure.Configurations.EventBus;
using I3Lab.Doctors.Infrastructure.Processing.Quartz;

namespace I3Lab.Doctors.Infrastructure.Startup
{
    public static class DoctorModuleStartup
    {
        public static IServiceCollection AddDoctorModule(
         this IServiceCollection services, IConfiguration configuration)
        {

            services.AddApplicationServices(configuration);

            services.AddPersistenceServices(configuration);

            services.AddMassTransitEventBus(configuration);

            QuartzStartup.Initialize();

            return services;
        }
    }
}
