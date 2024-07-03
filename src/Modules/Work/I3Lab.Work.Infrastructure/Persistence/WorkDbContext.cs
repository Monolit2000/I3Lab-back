using I3Lab.Works.Domain.WorkDirectorys;
using I3Lab.Works.Domain.Works;
using Microsoft.EntityFrameworkCore;

namespace I3Lab.Works.Infrastructure.Persistence
{
    public class WorkDbContext : DbContext
    {
        public DbSet<WorkDirectory> WorkDirectories { get; set; }

        public DbSet<Work> Works { get; set; }

        public WorkDbContext(DbContextOptions<WorkDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<WorkDirectory>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasMany(e => e.Files3Ds).WithOne().HasForeignKey(f => f.WorkDirectoryId);
                entity.HasMany(e => e.OtherFiles).WithOne().HasForeignKey(f => f.WorkDirectoryId);
            });

            modelBuilder.Entity<Work>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasMany(e => e.WorkFiles).WithOne().HasForeignKey(f => f.WorkId);
                entity.HasMany(e => e.WorkMembers).WithOne().HasForeignKey(m => m.WorkId);
            });
        }
    }
}
