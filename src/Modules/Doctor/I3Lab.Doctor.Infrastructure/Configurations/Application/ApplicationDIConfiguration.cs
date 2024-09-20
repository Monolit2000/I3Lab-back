using I3Lab.Doctors.Domain.Doctors;
using I3Lab.Doctors.Application.Contract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using I3Lab.Doctors.Application.Contract.Commands;
using I3Lab.Doctors.Infrastructure.Domain.Doctors;
using I3Lab.Doctors.Domain.DoctorCreationProposals;
using I3Lab.Doctors.Infrastructure.Processing.InternalCommands;
using I3Lab.Doctors.Infrastructure.Domain.DoctorCreationProposals;

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
                cfg.RegisterServicesFromAssembly(typeof(CommandsScheduler).Assembly);
            });
               
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<ICommandsScheduler, CommandsScheduler>();
            services.AddScoped<IDoctorCreationProposalRepository, DoctorCreationProposalRepository>();

            return services;
        }
    }
}
