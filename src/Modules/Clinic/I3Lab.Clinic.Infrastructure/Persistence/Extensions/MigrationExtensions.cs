using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Clinics.Infrastructure.Persistence.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyClinicContextMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using ClinicContext workContext = scope.ServiceProvider.GetRequiredService<ClinicContext>();

            workContext.Database.Migrate();
        }
    }
}
