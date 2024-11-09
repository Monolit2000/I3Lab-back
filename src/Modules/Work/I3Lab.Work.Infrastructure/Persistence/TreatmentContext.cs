using Microsoft.EntityFrameworkCore;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.TreatmentFiles;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Domain.TreatmentInvites;
using I3Lab.Treatments.Domain.TreatmentStageChats;
using I3Lab.BuildingBlocks.Infrastructure.InternalCommands;
using Microsoft.EntityFrameworkCore.Design;
using System.Configuration;

namespace I3Lab.Treatments.Infrastructure.Persistence
{
    public class TreatmentContext : DbContext
    {
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<TreatmentFile> TreatmentFiles { get; set; }
        public DbSet<TreatmentStageChat> TreatmentStageChats { get; set; }
        public DbSet<TreatmentInvite> TreatmentInvites { get; set; }
        public DbSet<InternalCommand> InternalCommands { get; set; }
        public DbSet<Treatments.Domain.TreatmentStages.TreatmentStage> TreatmentStages { get; set; }
        public DbSet<Member> Members { get; set; }

        public TreatmentContext(DbContextOptions<TreatmentContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("treatment");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TreatmentContext).Assembly);

        }
    }
}

