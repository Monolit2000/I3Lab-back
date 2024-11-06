using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace I3Lab.Treatments.Infrastructure.Domain.Works
{
    public class TreatmentStageConfiguration : IEntityTypeConfiguration<I3Lab.Treatments.Domain.TreatmentStages.TreatmentStage>
    {
        public void Configure(EntityTypeBuilder<I3Lab.Treatments.Domain.TreatmentStages.TreatmentStage> builder)
        {
            builder.ToTable("TreatmentStage");

            builder.HasKey(e => e.Id);

            //builder.Property(e => e.TreatmentId).HasConversion<WorkIdConverter>();

            //builder.Property(e => e.Creator).IsRequired();

            builder.Property(e => e.TreatmentId);

            builder.HasOne(e => e.Creator)
                .WithMany();

            // builder.Property(e => e.Customer).IsRequired();

            //builder.HasOne(e => e.Customer)
            //      .WithMany();

            builder.HasMany(e => e.TreatmentStageFiles)
                .WithOne()
                .HasForeignKey(f => f.TreatmentStageId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.OwnsOne(e => e.Titel, b =>
            {
                b.Property(t => t.Value).HasColumnName("TreatmentTitel").IsRequired();
            });

            //builder.Property(e => e.TreatmentStageStartedDate).IsRequired();

            builder.ComplexProperty(o => o.TreatmentStageStatus, b =>
            {
                b.IsRequired();
                b.Property(a => a.Value).HasColumnName("TreatmentStageStatus");
            });

            builder.OwnsOne(ts => ts.TreatmentStageDate);

            //builder.OwnsOne(ts => ts.TreatmentStageDate, b => 
            //{
            //    b.Property(date => date.StageStarted).IsRequired();
            //    b.Property(date => date.StageFinished);
            //});

            //builder.OwnsMany(e => e.TreatmentStageFiles, b =>
            //{

            //    b.HasKey(wf => wf.File);

            //    b.Property(wf => wf.File)
            //        .HasConversion<BlobFileIdConverter>()
            //        .IsRequired();

            //    b.Property(wf => wf.TreatmentId)
            //        .HasConversion<WorkIdConverter>()
            //        .IsRequired();

            //    b.HasIndex(wf => new { wf.TreatmentId, wf.File }).IsUnique();
            //});


            //builder.HasMany(e => e.TreatmentAccebilityMembers)
            //    .WithOne()
            //    .HasForeignKey(m => m.TreatmentId)
            //    .OnDelete(DeleteBehavior.Cascade)
            //    .IsRequired();


            //builder.OwnsMany(e => e.TreatmentAccebilityMembers, b =>
            //{
            //    b.HasKey(wm => new { wm.TreatmentStageId, wm.Member });


            //    b.Property(wm => wm.TreatmentStageId).IsRequired();

            //    //b.OwnsOne(o => o.TreatmentId, b =>
            //    //{
            //    //    b.Property(a => a.Value).HasColumnName("TreatmentId").IsRequired();
            //    //});

            //    b.Property(wm => wm.Member).IsRequired();
            //    b.Property(wm => wm.AddedBy).IsRequired();
            //    b.Property(wm => wm.JoinDate).IsRequired();

            //    b.OwnsOne(at => at.AccessibilityType, b =>
            //    {
            //        b.Property(a => a.Value).HasColumnName("AccessibilityType");
            //    });

            //    // Уникальный индекс для WorkMember
            //    b.HasIndex(wm => new { wm.TreatmentStageId, wm.Member }).IsUnique();
            //});

        }
    }
}
