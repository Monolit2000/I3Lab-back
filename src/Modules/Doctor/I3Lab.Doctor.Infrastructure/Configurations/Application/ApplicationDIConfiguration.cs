using I3Lab.Doctors.Application.Contract;
using I3Lab.Doctors.Domain.DoctorCreationProposals;
using I3Lab.Doctors.Domain.Doctors;
using I3Lab.Doctors.Infrastructure.Domain.DoctorCreationProposals;
using I3Lab.Doctors.Infrastructure.Domain.Doctors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace I3Lab.Doctors.Infrastructure.Configurations.Application
{
    public static class ApplicationDIConfiguration
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services, IConfiguration configuration)
        {

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(DoctorModule).Assembly);
            });


            services.AddScoped<IDoctorCreationProposalRepository, DoctorCreationProposalRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();

            return services;
        }
    }
}
