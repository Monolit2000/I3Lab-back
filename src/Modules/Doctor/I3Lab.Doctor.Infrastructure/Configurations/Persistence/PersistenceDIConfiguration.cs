using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using I3Lab.BuildingBlocks.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Diagnostics;
using I3Lab.BuildingBlocks.Infrastructure.Domain;
using I3Lab.Doctors.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;


namespace I3Lab.Doctors.Infrastructure.Configurations.Persistence
{
    public static class PersistenceDIConfiguration
    {
        public static IServiceCollection AddPersistenceServices(
           this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

            services.AddDbContext<DoctorContext>((sp, options) =>
            {
                options.ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();
                options.UseNpgsql(configuration.GetConnectionString("Database"));
                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            });

            return services;
        }
    }
}
