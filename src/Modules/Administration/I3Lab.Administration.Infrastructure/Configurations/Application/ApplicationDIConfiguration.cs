using I3Lab.Administration.Application.Contruct;
using I3Lab.Administration.Domain.DoctorCreationProposals;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using I3Lab.Administration.Infrastructure.Domain.DoctorCreationProposals;

namespace I3Lab.Administration.Infrastructure.Configurations.Application
{
    public static class ApplicationDIConfiguration
    {
        public static IServiceCollection AddApplicationServices(
         this IServiceCollection services, IConfiguration configuration)
        {

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(AdministrationModule).Assembly);
            });

            services.AddScoped<IDoctorCreationProposalRepository, DoctorCreationProposalRepository>();

            return services;
        }
    }
}
