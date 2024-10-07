using Microsoft.EntityFrameworkCore;
using I3Lab.Clinics.Domain.Clinics;
using I3Lab.Clinics.Infrastructure.Domain.Clinics;
using I3Lab.Clinics.Domain.ClinicCreationProposals;

namespace I3Lab.Clinics.Infrastructure.Persistence
{
    public class ClinicContext : DbContext
    {
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<ClinicCreationProposal> ClinicCreationProposals { get; set; }

        public ClinicContext(DbContextOptions<ClinicContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("clinic");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClinicContext).Assembly);

        }
    }
}
