using Hangfire;
using Hangfire.MemoryStorage;
using Testcontainers.PostgreSql;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Mvc.Testing;
using I3Lab.BuildingBlocks.Infrastructure;
using I3Lab.Users.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using I3Lab.Clinics.Infrastructure.Persistence;
using I3Lab.Doctors.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore.Diagnostics;
using I3Lab.Treatments.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection.Extensions;
using I3Lab.Modules.BlobFailes.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;


namespace I3lab.Users.IntegrationTests.Abstraction
{
    public class IntegrationTestWebAppFactory : WebApplicationFactory<I3Lab.API.Configuration.Program>, IAsyncLifetime
    {
        private readonly PostgreSqlContainer _dbContainer = new PostgreSqlBuilder()
            .WithImage("postgres:latest")
            .WithDatabase("SturtUp")
            .WithUsername("postgres")
            .WithPassword("postgress")
            .Build();

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                var constr = _dbContainer.GetConnectionString();

                RegisterDbContext<UserContext>(services, constr);
                RegisterDbContext<TreatmentContext>(services, constr);
                RegisterDbContext<DoctorContext>(services, constr);
                RegisterDbContext<ClinicContext>(services, constr);
                RegisterDbContext<BlobFileContext>(services, constr);

                services.AddHangfire(x =>
                    x.UseSimpleAssemblyNameTypeSerializer()
                    .UseRecommendedSerializerSettings()
                    .UseMemoryStorage());

            });
        }

        public async Task InitializeAsync()
        {
            await _dbContainer.StartAsync();
        }

        public new async Task DisposeAsync()
        {
            await _dbContainer.StopAsync();
        }

        private void RegisterDbContext<TContext>(IServiceCollection services, string connectionString) where TContext : DbContext
        {
            services.RemoveAll(typeof(DbContextOptions<TContext>));
            services.AddDbContext<TContext>((sp, options) =>
            {
                options.ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();
                options.UseNpgsql(connectionString);
                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            });
        }
    }
}

//if (!services.Any(s => s.ServiceType == typeof(IBusControl)))
//{
//    services.AddMassTransit(busConfiguration =>
//    {
//        busConfiguration.SetKebabCaseEndpointNameFormatter();

//        busConfiguration.UsingRabbitMq((context, configurator) =>
//        {
//            configurator.Host(new Uri(_rabbitMqUri), h =>
//            {
//                h.Username("guest");
//                h.Password("guest");
//            });

//            configurator.ConfigureEndpoints(context);
//        });
//    });





//services.RemoveAll(typeof(IBus));
//services.RemoveAll(typeof(IPublishEndpoint));
//services.RemoveAll(typeof(ISendEndpointProvider));
//services.RemoveAll<IHealthCheck>();

//var healthCheckDescriptor = services.FirstOrDefault(d => d.ImplementationType?.Name == "MassTransitHealthCheck");
//if (healthCheckDescriptor != null)
//{
//    services.Remove(healthCheckDescriptor);
//}

//services.AddMassTransit(busConfiguration =>
//{
//    busConfiguration.SetKebabCaseEndpointNameFormatter();

//    busConfiguration.UsingInMemory((context, config) => config.ConfigureEndpoints(context));
//});
