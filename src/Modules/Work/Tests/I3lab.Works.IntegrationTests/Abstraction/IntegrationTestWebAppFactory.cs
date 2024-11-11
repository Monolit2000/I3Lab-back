//using Hangfire;
//using System.Net;
//using System.Net.Sockets;
//using Hangfire.MemoryStorage;
//using Testcontainers.PostgreSql;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.TestHost;
//using Microsoft.EntityFrameworkCore;
//using DotNet.Testcontainers.Builders;
//using Microsoft.AspNetCore.Mvc.Testing;
//using I3Lab.BuildingBlocks.Infrastructure;
//using I3Lab.Users.Infrastructure.Persistence;
//using I3Lab.Clinics.Infrastructure.Persistence;
//using I3Lab.Doctors.Infrastructure.Persistence;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.EntityFrameworkCore.Diagnostics;
//using I3Lab.Treatments.Infrastructure.Persistence;
//using Microsoft.Extensions.DependencyInjection.Extensions;
//using I3Lab.Modules.BlobFailes.Infrastructure.Persistence;
//using Microsoft.EntityFrameworkCore.Storage.ValueConversion;


//namespace I3lab.Works.IntegrationTests.Abstraction
//{
//    public class IntegrationTestWebAppFactory : WebApplicationFactory<I3Lab.API.Configuration.Program>, IAsyncLifetime
//    {

//        private readonly PostgreSqlContainer _dbContainer = new PostgreSqlBuilder()
//            .WithImage("postgres:latest")
//            .WithDatabase("SturtUp")
//            .WithUsername("postgres")
//            .WithPassword("postgress")
//            //.WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(5432))
//            .Build();


//        protected override void ConfigureWebHost(IWebHostBuilder builder)
//        {
//            builder.ConfigureTestServices(services =>
//            {
//                services.RemoveAll(typeof(DbContextOptions<UserContext>));

//                var sdfdsf = _dbContainer.GetConnectionString();

//                var constr = _dbContainer.GetConnectionString();

//                services.AddDbContext<UserContext>((sp, options) =>
//                {
//                    options.ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();
//                    options.UseNpgsql(constr);
//                    options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
//                });



//                services.RemoveAll(typeof(DbContextOptions<TreatmentContext>));
//                services.AddDbContext<TreatmentContext>((sp, options) =>
//                {
//                    options.ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();
//                    options.UseNpgsql(constr);
//                    options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
//                });



//                services.RemoveAll(typeof(DbContextOptions<DoctorContext>));
//                services.AddDbContext<DoctorContext>((sp, options) =>
//                {
//                    options.UseNpgsql(constr);
//                    options.ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();
//                });


//                services.RemoveAll(typeof(DbContextOptions<ClinicContext>));
//                services.AddDbContext<ClinicContext>((sp, options) =>
//                {
//                    options.UseNpgsql(constr);
//                    options.ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();
//                });   
                
                
//                services.RemoveAll(typeof(DbContextOptions<BlobFileContext>));
//                services.AddDbContext<BlobFileContext>((sp, options) =>
//                {
//                    options.UseNpgsql(constr);
//                    options.ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();
//                });



//                services.AddHangfire(x =>
//                    x.UseSimpleAssemblyNameTypeSerializer()
//                    .UseRecommendedSerializerSettings()
//                    .UseMemoryStorage());
//                    //.UsePostgreSqlStorage(options => options.UseNpgsqlConnection(_dbContainer.GetConnectionString())));

//            });
//        }

//        public async Task InitializeAsync()
//        {
//            await _dbContainer.StartAsync();
//        }

//        public new async Task DisposeAsync()
//        {
//            await _dbContainer.StopAsync();
//        }

       
//    }
//}
