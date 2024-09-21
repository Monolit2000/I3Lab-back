using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace I3Lab.Treatments.Infrastructure.Persistence.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyWorkContextMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using TreatmentContext workContext = scope.ServiceProvider.GetRequiredService<TreatmentContext>();

            //workContext.Database.EnsureDeleted();

            workContext.Database.Migrate();
        }
    }
}
