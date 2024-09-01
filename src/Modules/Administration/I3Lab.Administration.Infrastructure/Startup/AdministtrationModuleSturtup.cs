using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using I3Lab.Administration.Infrastructure.Configurations.Persistence;
using I3Lab.Administration.Infrastructure.Configurations.EventBus;

namespace I3Lab.Administration.Infrastructure.Startup
{
    public static class AdministtrationModuleSturtup
    {
        public static IServiceCollection AddWorkModule(
             this IServiceCollection services, IConfiguration configuration)
        {

            //services.AddApplicationServices(configuration);

            services.AddPersistenceServices(configuration);

            services.AddMassTransitEventBus(configuration);

            return services;
        }
    }
}
