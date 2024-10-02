using I3Lab.BuildingBlocks.Infrastructure;
using I3Lab.BuildingBlocks.Infrastructure.Domain;
using I3Lab.Clinics.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;


namespace I3Lab.Clinics.Infrastructure.Configurations.Persistence
{
    public static class PersistenceDIConfiguration
    {
        public static IServiceCollection AddPersistenceServices(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

            services.AddDbContext<ClinicContext>((sp, options) =>
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
