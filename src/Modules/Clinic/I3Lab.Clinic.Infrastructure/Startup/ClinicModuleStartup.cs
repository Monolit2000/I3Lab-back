﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using I3Lab.Clinics.Infrastructure.Configurations.Persistence;
using I3Lab.Clinics.Infrastructure.Configurations.Application;

namespace I3Lab.Clinics.Infrastructure.Startup
{
    public static class ClinicModuleStartup
    {
        public static IServiceCollection AddClinicModule(
        this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationServices(configuration);

            services.AddPersistenceServices(configuration);

            return services;
        }
    }
}