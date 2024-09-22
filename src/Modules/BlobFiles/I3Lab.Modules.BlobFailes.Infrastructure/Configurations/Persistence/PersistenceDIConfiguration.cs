using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using I3Lab.BuildingBlocks.Infrastructure;
using Microsoft.EntityFrameworkCore;
using I3Lab.BuildingBlocks.Infrastructure.Domain;

using I3Lab.Modules.BlobFailes.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace I3Lab.Modules.BlobFailes.Infrastructure.Configurations.Persistence
{
    public static class PersistenceDIConfiguration
    {
        public static IServiceCollection AddPersistenceServices(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

            services.AddDbContext<BlobFileContext>((sp, options) =>
            {
                options.ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();
                options.UseNpgsql(configuration.GetConnectionString("Database"));
                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            });

            // services.AddScoped<TreatmentContext>();

            return services;
        }
    }
}
