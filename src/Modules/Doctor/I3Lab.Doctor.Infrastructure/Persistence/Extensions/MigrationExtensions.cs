using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace I3Lab.Doctors.Infrastructure.Persistence.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyWorkContextMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using DoctorContext workContext = scope.ServiceProvider.GetRequiredService<DoctorContext>();

            //workContext.Database.EnsureDeleted();

            workContext.Database.Migrate();
        }
    }
}
