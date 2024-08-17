using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace I3Lab.Users.Infrastructure.Persistence.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations( this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using UserContext userContext = scope.ServiceProvider.GetRequiredService<UserContext>();

            userContext.Database.Migrate();
        }
    }
}
