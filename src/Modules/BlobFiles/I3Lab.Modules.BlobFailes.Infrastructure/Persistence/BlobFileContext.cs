using Microsoft.EntityFrameworkCore;
using I3Lab.Modules.BlobFailes.Domain.BlobFiles;
using I3Lab.Modules.BlobFailes.Infrastructure.Domain.BlobFiles;

namespace I3Lab.Modules.BlobFailes.Infrastructure.Persistence
{
    public class BlobFileContext : DbContext
    {
        public DbSet<BlobFile> BlobFiles { get; set; }

        public BlobFileContext(DbContextOptions<BlobFileContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BlobFileConfiguration());

        }
    }
}
