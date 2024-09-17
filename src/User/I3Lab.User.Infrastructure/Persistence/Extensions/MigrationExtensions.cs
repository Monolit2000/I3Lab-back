using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Entity;


namespace I3Lab.Users.Infrastructure.Persistence.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyUserContextMigrations( this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using UserContext userContext = scope.ServiceProvider.GetRequiredService<UserContext>();

            userContext.Database.Migrate();
        }
    }
}
