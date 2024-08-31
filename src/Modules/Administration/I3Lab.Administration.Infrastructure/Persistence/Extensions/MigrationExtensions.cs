using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace I3Lab.Administration.Infrastructure.Persistence.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyDoctorContextMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using AdministrationContext administrationContext = scope.ServiceProvider.GetRequiredService<AdministrationContext>();

            //workContext.Database.EnsureDeleted();

            administrationContext.Database.Migrate();
        }
    }
}
