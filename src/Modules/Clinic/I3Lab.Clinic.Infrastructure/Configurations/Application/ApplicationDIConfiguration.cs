using I3Lab.Clinics.Application.Conruct;
using I3Lab.Clinics.Domain.Clnics;
using I3Lab.Clinics.Infrastructure.Domain.Clinics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace I3Lab.Clinics.Infrastructure.Configurations.Application
{
    public static class ApplicationDIConfiguration
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services, IConfiguration configuration)
        {

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(IClinicModule).Assembly);
                //cfg.RegisterServicesFromAssembly(typeof(ProcessInternalCommandsCommandHandler).Assembly);

            });

            services.AddScoped<IClinicRepository, ClinicRepository>();

            return services;
        }
    }
}
