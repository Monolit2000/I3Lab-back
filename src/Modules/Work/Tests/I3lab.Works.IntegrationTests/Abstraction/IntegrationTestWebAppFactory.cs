using I3Lab.BuildingBlocks.Infrastructure;
using I3Lab.Doctors.Infrastructure.Persistence;
using I3Lab.Treatments.Infrastructure.Persistence;
using I3Lab.Users.Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Testcontainers.PostgreSql;


namespace I3lab.Works.IntegrationTests.Abstraction
{
    public class IntegrationTestWebAppFactory : WebApplicationFactory<I3Lab.API.Configuration.Program>, IAsyncLifetime
    {
        private readonly PostgreSqlContainer _dbContainer = new PostgreSqlBuilder()
            .WithImage("postgres:latest")
            .WithDatabase("SturtUp")
            .WithUsername("postgres")
            .WithPassword("postgres")
            //.WithExposedPort(5432) // Убедитесь, что порт открыт
            //.WithCommand("postgres", "-c", "max_connections=1000")
            .Build();

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                services.RemoveAll(typeof(DbContextOptions<UserContext>));

                services.AddDbContext<UserContext>((sp, options) =>
                {
                    options.ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();
                    options.UseNpgsql(_dbContainer.GetConnectionString());
                    options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
                    //options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                });


                //TreatmentContext//////////////////////////////////////////////////////////////////////
                //services.RemoveAll(typeof(DbContextOptions<TreatmentContext>));
                //services.AddDbContext<TreatmentContext>(options =>
                //options
                //     .UseNpgsql(_dbContainer.GetConnectionString())
                //     .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>());

                services.AddDbContext<TreatmentContext>((sp, options) =>
                {
                    options.ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();
                    options.UseNpgsql(_dbContainer.GetConnectionString());
                    options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
                });

                //TreatmentContext//////////////////////////////////////////////////////////////////////


                services.RemoveAll(typeof(DbContextOptions<DoctorContext>));
                services.AddDbContext<DoctorContext>((sp, options) =>
                {
                    options.UseNpgsql(_dbContainer.GetConnectionString());
                    options.ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();
                });
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
    }
}
