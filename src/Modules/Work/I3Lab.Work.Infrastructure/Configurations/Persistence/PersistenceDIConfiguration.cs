using I3Lab.Works.Domain.Works;
using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.BlobFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using I3Lab.BuildingBlocks.Infrastructure;
using I3Lab.Works.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Diagnostics;
using I3Lab.BuildingBlocks.Infrastructure.Domain;

using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace I3Lab.Works.Infrastructure.Configurations.Persistence
{
    public static class PersistenceDIConfiguration
    {
        public static IServiceCollection AddPersistenceServices(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

            services.AddDbContext<WorkContext>((sp, options) =>
            {
                options.ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();
                options.UseNpgsql(configuration.GetConnectionString("Database"));
                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            });

            return services;
        }
    }
}
