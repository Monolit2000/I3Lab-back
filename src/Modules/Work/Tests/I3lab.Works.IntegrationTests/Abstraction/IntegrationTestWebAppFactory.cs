using I3Lab.BuildingBlocks.Infrastructure;
using I3Lab.Doctors.Infrastructure.Persistence;
using I3Lab.Treatments.Infrastructure.Persistence;
using I3Lab.Users.Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Testcontainers.PostgreSql;

namespace I3lab.Works.IntegrationTests.Abstraction
{
    public class IntegrationTestWebAppFactory : WebApplicationFactory<I3Lab.API.Configuration.Program>, IAsyncLifetime
    {
        private readonly PostgreSqlContainer _dbContainer = new PostgreSqlBuilder()
            .WithImage("postgres:latest")
            .WithDatabase("SturtUp")
            .WithUsername("postgress")
            .WithPassword("postgresss")
            .Build();

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                services.RemoveAll(typeof(DbContextOptions<UserContext>));

                services.AddDbContext<UserContext>(options =>
                options
                    .UseNpgsql(_dbContainer.GetConnectionString())
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

                services.RemoveAll(typeof(DbContextOptions<TreatmentContext>));

                services.AddDbContext<TreatmentContext>(options =>
                options
                     .UseNpgsql(_dbContainer.GetConnectionString())
                     .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>());

                services.RemoveAll(typeof(DbContextOptions<DoctorContext>));

                services.AddDbContext<DoctorContext>(options =>
                options
                     .UseNpgsql(_dbContainer.GetConnectionString())
                     .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>());
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
