using I3Lab.Clinics.Domain.Clinics;
using I3Lab.Clinics.Domain.Doctors;
using I3Lab.Clinics.Application.Contruct;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using I3Lab.Clinics.Infrastructure.Domain.Clinics;
using I3Lab.Clinics.Domain.DoctorCreationProposals;
using I3Lab.Clinics.Infrastructure.Domain.Doctors;
using I3Lab.Clinics.Infrastructure.Domain.DoctorCreationProposals;

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
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IDoctorCreationProposalRepository, DoctorCreationProposalRepository>();

            return services;
        }
    }
}
