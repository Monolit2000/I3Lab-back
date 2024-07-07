using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.Treatment;
using I3Lab.Works.Domain.WorkComments;
using I3Lab.Works.Domain.WorkDirectorys;
using I3Lab.Works.Domain.Works;
using I3Lab.Works.Infrastructure.Domain.WorkDirectorys;
using I3Lab.Works.Infrastructure.Domain.Works;
using Microsoft.EntityFrameworkCore;

namespace I3Lab.Works.Infrastructure.Persistence
{
    public class WorkDbContext : DbContext
    {
        public DbSet<Works.Domain.WorkDirectorys.WorkDirectory> WorkDirectories { get; set; }

        public DbSet<Work> Works { get; set; }

        public DbSet<WorkComment> WorkComments { get; set; }

        public DbSet<Treatment> Treatments { get; set; }

        public DbSet<Member> Members { get; set; }

        public WorkDbContext(DbContextOptions<WorkDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new WorkDirectoryConfiguration());

            modelBuilder.ApplyConfiguration(new WorkEntityTypeConfiguration());

         
        }
    }
}
