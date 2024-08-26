using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace I3Lab.Doctors.Infrastructure.Persistence.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyDoctorContextMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using DoctorContext doctorContext = scope.ServiceProvider.GetRequiredService<DoctorContext>();

            //workContext.Database.EnsureDeleted();

            doctorContext.Database.Migrate();
        }
    }
}
