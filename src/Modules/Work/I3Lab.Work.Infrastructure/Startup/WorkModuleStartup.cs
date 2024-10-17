using I3Lab.Treatments.Domain.TreatmentStages;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.TreatmentFiles;
using I3Lab.Treatments.Domain.Treatments;
using Microsoft.EntityFrameworkCore;
using I3Lab.Treatments.Application.Contract;
using Microsoft.Extensions.Configuration;
using I3Lab.BuildingBlocks.Infrastructure;
using I3Lab.Treatments.Infrastructure.Persistence;
using I3Lab.Treatments.Infrastructure.Domain.Works;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Diagnostics;
using I3Lab.BuildingBlocks.Infrastructure.Domain;
using I3Lab.Treatments.Infrastructure.Domain.Members;
using I3Lab.Treatments.Infrastructure.Domain.TreatmentFiles;
using I3Lab.Treatments.Infrastructure.Domain.Treatments;
using I3Lab.Treatments.Infrastructure.Configurations.EventBus;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using I3Lab.Treatments.Infrastructure.Configurations.Persistence;
using I3Lab.Treatments.Infrastructure.Configurations.Application;
using I3Lab.Treatments.Infrastructure.Processing.Quartz;


namespace I3Lab.Treatments.Infrastructure.Startup
{
    public static class WorkModuleStartup
    {
        public static IServiceCollection AddTreatmentModule(
         this IServiceCollection services, IConfiguration configuration)
        {

            services.AddApplicationServices(configuration);

            services.AddPersistenceServices(configuration);

            services.AddMassTransitEventBus(configuration);

            QuartzStartup.Initialize();

            return services;
        }
    }
}
