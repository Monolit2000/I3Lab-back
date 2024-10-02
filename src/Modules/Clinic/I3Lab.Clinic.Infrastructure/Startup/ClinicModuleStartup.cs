using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using I3Lab.Clinics.Infrastructure.Configurations.Persistence;

namespace I3Lab.Clinics.Infrastructure.Startup
{
    public static class ClinicModuleStartup
    {
        public static IServiceCollection AddClinicModule(
        this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistenceServices(configuration);

            return services;
        }
    }
}
