using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace I3Lab.Works.Infrastructure.Persistence.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyWorkContextMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using WorkContext userContext = scope.ServiceProvider.GetRequiredService<WorkContext>();

            userContext.Database.Migrate();
        }
    }
}
