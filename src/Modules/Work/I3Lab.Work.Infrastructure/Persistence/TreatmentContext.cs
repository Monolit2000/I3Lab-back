using I3Lab.Treatments.Domain.BlobFiles;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.TreatmentStages;
using I3Lab.Treatments.Infrastructure.Domain.Works;
using I3Lab.Treatments.Infrastructure.Domain.Members;
using Microsoft.EntityFrameworkCore;
using I3Lab.Treatments.Infrastructure.Domain.BlobFiles;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Infrastructure.Domain.Treatments;
using I3Lab.Treatments.Domain.TreatmentInvites;
using I3Lab.Treatments.Domain.TreatmentStageChats;
using I3Lab.Treatments.Infrastructure.Domain.WorkChats;
using I3Lab.Treatments.Infrastructure.Domain.TreatmentInvites;
using I3Lab.BuildingBlocks.Infrastructure.InternalCommands;

namespace I3Lab.Treatments.Infrastructure.Persistence
{
    public class TreatmentContext : DbContext
    {
        //public DbSet<TreatmentStages.Domain.WorkDirectorys.WorkDirectory> WorkDirectories { get; set; }

        //public DbSet<WorkComment> TreatmentStageComments { get; set; }
        public DbSet<TreatmentStageChat> WorkChats { get; set; }

        public DbSet<TreatmentInvite> TreatmentInvites { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Treatments.Domain.TreatmentStages.TreatmentStage> Works { get; set; }

        public DbSet<InternalCommand> InternalCommands { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<BlobFile> BlobFiles { get; set; }

        public TreatmentContext(DbContextOptions<TreatmentContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("work");

            modelBuilder.ApplyConfiguration(new MemberConfiguration());

            modelBuilder.ApplyConfiguration(new TreatmentStageConfiguration());

            modelBuilder.ApplyConfiguration(new WorkChatConfiguration());

            //modelBuilder.ApplyConfiguration(new ChatMessageConfiguration());

            modelBuilder.ApplyConfiguration(new BlobFileConfiguration());

            modelBuilder.ApplyConfiguration(new WorkTreatmentStageConfiguration());

            modelBuilder.ApplyConfiguration(new TreatmentConfiguration());
            
            modelBuilder.ApplyConfiguration(new TreatmentInviteConfiguration());

            //modelBuilder.Ignore<TreatmentInvite>();

            //modelBuilder.ApplyConfiguration(new TreatmentConfiguration());


            //modelBuilder.Ignore<Treatment>();

        }
    }
}

            //modelBuilder.ApplyConfiguration(new WorkDirectoryConfiguration());