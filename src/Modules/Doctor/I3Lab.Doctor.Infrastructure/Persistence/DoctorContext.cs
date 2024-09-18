using I3Lab.Doctors.Domain.Doctors;
using Microsoft.EntityFrameworkCore;
using I3Lab.Doctors.Domain.DoctorCreationProposals;
using I3Lab.Doctors.Infrastructure.Domain.DoctorCreationProposals;
using I3Lab.Doctors.Infrastructure.Domain.Doctors;

namespace I3Lab.Doctors.Infrastructure.Persistence
{
    public class DoctorContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<DoctorCreationProposal> DoctorCreationProposals { get; set; }

        public DoctorContext(DbContextOptions<DoctorContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("doctors");

            modelBuilder.ApplyConfiguration(new DoctorCreationProposalConfiguration());

            modelBuilder.ApplyConfiguration(new DoctorConfiguration());
        }
    }
}
 