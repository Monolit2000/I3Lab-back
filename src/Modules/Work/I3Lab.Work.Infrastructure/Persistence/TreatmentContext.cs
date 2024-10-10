using Microsoft.EntityFrameworkCore;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.TreatmentFiles;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Domain.TreatmentInvites;
using I3Lab.Treatments.Domain.TreatmentStageChats;
using I3Lab.BuildingBlocks.Infrastructure.InternalCommands;

namespace I3Lab.Treatments.Infrastructure.Persistence
{
    public class TreatmentContext : DbContext
    {
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<TreatmentFile> TreatmentFiles { get; set; }
        public DbSet<TreatmentStageChat> WorkChats { get; set; }
        public DbSet<TreatmentInvite> TreatmentInvites { get; set; }
        public DbSet<InternalCommand> InternalCommands { get; set; }
        public DbSet<Treatments.Domain.TreatmentStages.TreatmentStage> Works { get; set; }
        public DbSet<Member> Members { get; set; }

        public TreatmentContext(DbContextOptions<TreatmentContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("treatment");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TreatmentContext).Assembly);


            //modelBuilder.ApplyConfiguration(new MemberConfiguration());

            //modelBuilder.ApplyConfiguration(new TreatmentStageConfiguration());

            //modelBuilder.ApplyConfiguration(new WorkChatConfiguration());

            //modelBuilder.ApplyConfiguration(new TreatmentFileConfiguration());

            //modelBuilder.ApplyConfiguration(new TreatmentStageFileConfiguration());

            //modelBuilder.ApplyConfiguration(new TreatmentConfiguration());
            
            //modelBuilder.ApplyConfiguration(new TreatmentInviteConfiguration());

        }
    }
}

