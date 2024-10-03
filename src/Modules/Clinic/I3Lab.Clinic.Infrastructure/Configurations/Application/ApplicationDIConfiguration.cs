using I3Lab.Clinics.Application.Conruct;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            return services;
        }
    }
}
