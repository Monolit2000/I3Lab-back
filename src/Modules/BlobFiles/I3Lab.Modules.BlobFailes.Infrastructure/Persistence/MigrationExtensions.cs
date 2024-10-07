using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace I3Lab.Modules.BlobFailes.Infrastructure.Persistence
{
    public static class MigrationExtensions
    {
        public static void ApplyBlobFaileContextMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using BlobFileContext blobFileContext = scope.ServiceProvider.GetRequiredService<BlobFileContext>();

            //blobFileContext.Database.EnsureDeleted();
            blobFileContext.Database.Migrate();

        }
    }
}
