﻿using I3Lab.Users.Application.Contract;
using I3Lab.Users.Domain.Users;
using I3Lab.Users.Infrastructure.Domain;
using I3Lab.Users.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using I3Lab.Users.Infrastructure.JWT;
using I3Lab.Users.Infrastructure.Aplication;

namespace I3Lab.Users.Infrastructure.Startup
{
    public static class UserModuleStartup
    {
        public static IServiceCollection AddUserModule(
           this IServiceCollection services, IConfiguration configuration)
        {

            var connectionString = configuration.GetConnectionString("Database");

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(IJwtService).Assembly);
            });

            //services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

            services.AddDbContext<UserContext>((sp, options) =>
            {
                options.UseNpgsql(configuration.GetConnectionString("Database"));
                //options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            });

            services.AddApiAuthentication(configuration);

            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services; 



            //services.AddEventBusModule();
            //services.AddScoped<IUserAccessApi, UserAccessApi>();
            //services.AddScoped<IUserAccessModule, UserAccessModule>();
        }
    }
}