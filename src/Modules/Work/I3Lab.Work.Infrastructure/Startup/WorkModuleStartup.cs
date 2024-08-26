using I3Lab.Works.Domain.Works;
using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.BlobFiles;
using I3Lab.Works.Domain.Treatments;
using Microsoft.EntityFrameworkCore;
using I3Lab.Works.Application.Contract;
using Microsoft.Extensions.Configuration;
using I3Lab.BuildingBlocks.Infrastructure;
using I3Lab.Works.Infrastructure.Persistence;
using I3Lab.Works.Infrastructure.Domain.Works;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Diagnostics;
using I3Lab.BuildingBlocks.Infrastructure.Domain;
using I3Lab.Works.Infrastructure.Domain.Members;
using I3Lab.Works.Infrastructure.Domain.BlobFiles;
using I3Lab.Works.Infrastructure.Domain.Treatments;
using I3Lab.Works.Infrastructure.Configurations.EventBus;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using I3Lab.Works.Infrastructure.Configurations.Persistence;
using I3Lab.Works.Infrastructure.Configurations.Application;


namespace I3Lab.Works.Infrastructure.Startup
{
    public static class WorkModuleStartup
    {
        public static IServiceCollection AddWorkModule(
         this IServiceCollection services, IConfiguration configuration)
        {

            services.AddApplicationServices(configuration);

            services.AddPersistenceServices(configuration);

            services.AddMassTransitEventBus(configuration);

            return services;
        }
    }
}
