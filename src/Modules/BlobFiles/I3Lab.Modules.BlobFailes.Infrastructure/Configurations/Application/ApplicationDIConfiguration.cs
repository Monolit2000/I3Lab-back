using I3Lab.Modules.BlobFailes.Application.Contract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using I3Lab.Modules.BlobFailes.Infrastructure.Domain.BlobFiles;
using I3Lab.Modules.BlobFailes.Domain.BlobFiles;

namespace I3Lab.Modules.BlobFailes.Infrastructure.Configurations.Application
{
    public static class ApplicationDIConfiguration
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services, IConfiguration configuration)
        {

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(IBlobFilesModule).Assembly);
                //cfg.RegisterServicesFromAssembly(typeof(ProcessInternalCommandsCommandHandler).Assembly);

            });

            //services.AddScoped<ICommandsScheduler, CommandsScheduler>();

            services.AddScoped<IBlobFileRepository, BlobFileRepository>();

            return services;
        }
    }
}
