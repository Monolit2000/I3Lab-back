using Microsoft.EntityFrameworkCore;
using I3Lab.Administration.Domain.DoctorCreationProposals;

namespace I3Lab.Administration.Infrastructure.Persistence
{
    public class AdministrationContext : DbContext
    {

        public DbSet<DoctorCreationProposal> DoctorCreationProposals { get; set; }

        public AdministrationContext(DbContextOptions<AdministrationContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("administration");
        }
    }
}
