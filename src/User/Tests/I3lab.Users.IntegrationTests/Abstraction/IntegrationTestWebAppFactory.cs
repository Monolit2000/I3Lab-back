﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Testcontainers.PostgreSql;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.EntityFrameworkCore;
using I3Lab.Users.Infrastructure.Persistence;
using Npgsql;
using I3Lab.Works.Infrastructure.Persistence;
using I3Lab.BuildingBlocks.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Options;
namespace I3lab.Users.IntegrationTests.Abstraction
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


                services.RemoveAll(typeof(DbContextOptions<WorkContext>));

                services.AddDbContext<WorkContext>(options =>
                options
                     .UseNpgsql(_dbContainer.GetConnectionString())
                     .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>());
            });

            base.ConfigureWebHost(builder);
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