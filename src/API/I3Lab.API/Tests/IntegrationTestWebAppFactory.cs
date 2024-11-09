using DotNet.Testcontainers.Builders;
using Hangfire;
using Hangfire.PostgreSql;
using I3Lab.BuildingBlocks.Infrastructure;
using I3Lab.Clinics.Infrastructure.Persistence;
using I3Lab.Doctors.Infrastructure.Persistence;
using I3Lab.Modules.BlobFailes.Infrastructure.Persistence;
using I3Lab.Treatments.Infrastructure.Persistence;
using I3Lab.Users.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Net.Sockets;
using System.Net;
using Testcontainers.PostgreSql;
using Xunit;


namespace I3Lab.API.Tests
{
    public class IntegrationTestWebAppFactory : WebApplicationFactory<I3Lab.API.Configuration.Program>, IAsyncLifetime
    {
        private static int Port = GetFreeTcpPort();

        private readonly PostgreSqlContainer _dbContainer = new PostgreSqlBuilder()
            .WithImage("postgres:latest")
            .WithDatabase("SturtUp")
            .WithUsername("postgres")
            .WithPassword("postgress")
            //.WithPortBinding(GetFreeTcpPort(), 5432)
            //.WithCommand("postgres", "-c", "max_connections=1000")
            //.WithNetwork("test_network")
            .WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(5432))
            .Build();

        private readonly string _conString = $"Host=localhost;Port={Port};Database=SturtUp;Username=postgres;Password=postgress";

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                services.RemoveAll(typeof(DbContextOptions<UserContext>));

                var sdfdsf = _dbContainer.GetConnectionString();

                var constr = _dbContainer.GetConnectionString();

                services.AddDbContext<UserContext>((sp, options) =>
                {
                    options.ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();
                    options.UseNpgsql(constr);
                    options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
                });



                services.RemoveAll(typeof(DbContextOptions<TreatmentContext>));
                services.AddDbContext<TreatmentContext>((sp, options) =>
                {
                    options.ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();
                    options.UseNpgsql(constr);
                    options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
                });



                services.RemoveAll(typeof(DbContextOptions<DoctorContext>));
                services.AddDbContext<DoctorContext>((sp, options) =>
                {
                    options.UseNpgsql(constr);
                    options.ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();
                });


                services.RemoveAll(typeof(DbContextOptions<ClinicContext>));
                services.AddDbContext<ClinicContext>((sp, options) =>
                {
                    options.UseNpgsql(constr);
                    options.ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();
                });


                services.RemoveAll(typeof(DbContextOptions<BlobFileContext>));
                services.AddDbContext<BlobFileContext>((sp, options) =>
                {
                    options.UseNpgsql(constr);
                    options.ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();
                });



                services.AddHangfire(x =>
                    x.UseSimpleAssemblyNameTypeSerializer()
                    .UseRecommendedSerializerSettings()
                    .UsePostgreSqlStorage(options => options.UseNpgsqlConnection(_dbContainer.GetConnectionString())));

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

        public static int GetFreeTcpPort()
        {
            using (var tcpListener = new TcpListener(IPAddress.Loopback, 0))
            {
                tcpListener.Start();
                var port = ((IPEndPoint)tcpListener.LocalEndpoint).Port;
                tcpListener.Stop();
                return port;
            }
        }
    }
}
