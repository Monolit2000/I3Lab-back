using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Users.Infrastructure.Persistence.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations( this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using UserContext context = scope.ServiceProvider.GetRequiredService<UserContext>();

            context.Database.Migrate();
        }
    }
}
