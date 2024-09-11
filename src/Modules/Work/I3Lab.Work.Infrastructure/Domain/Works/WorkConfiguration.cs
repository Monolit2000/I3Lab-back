using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using I3Lab.Works.Domain.Works;
using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.Treatments;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using I3Lab.Works.Domain.BlobFiles;


namespace I3Lab.Works.Infrastructure.Domain.Works
{
    public class WorkConfiguration : IEntityTypeConfiguration<Work>
    {
        public void Configure(EntityTypeBuilder<Work> builder)
        {
            builder.HasKey(e => e.Id);

            //builder.Property(e => e.Id).HasConversion<WorkIdConverter>();

            //builder.Property(e => e.Creator).IsRequired();

            builder.HasOne(e => e.Creator)
                .WithMany();

            // builder.Property(e => e.Customer).IsRequired();

            builder.HasOne(e => e.Customer)
                  .WithMany();

            builder.HasMany(e => e.WorkFiles)
                .WithOne()
                .HasForeignKey(f => f.WorkId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.OwnsOne(e => e.Titel, b =>
            {
                b.Property(t => t.Value).HasColumnName("Titel").IsRequired();
            });

            builder.Property(e => e.WorkStartedDate).IsRequired();

            builder.ComplexProperty(o => o.WorkStatus, b =>
            {
                b.IsRequired();
                b.Property(a => a.Value).HasColumnName("WorkStatus");
            });

            //builder.OwnsMany(e => e.WorkFiles, b =>
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


            //builder.HasMany(e => e.WorkMembers)
            //    .WithOne()
            //    .HasForeignKey(m => m.TreatmentId)
            //    .OnDelete(DeleteBehavior.Cascade)
            //    .IsRequired();


            //builder.OwnsMany(e => e.WorkMembers, b =>
            //{
            //    b.HasKey(wm => new { wm.WorkId, wm.Member });


            //    b.Property(wm => wm.WorkId).IsRequired();

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
            //    b.HasIndex(wm => new { wm.WorkId, wm.Member }).IsUnique();
            //});

        }
    }

    //public class WorkIdConverter : ValueConverter<TreatmentId, Guid>
    //{
    //    public WorkIdConverter()
    //        : base(id => id.Value, value => new TreatmentId(value)) { }
    //}

    //public class TreatmentIdConverter : ValueConverter<TreatmentId, Guid>
    //{
    //    public TreatmentIdConverter()
    //        : base(id => id.Value, value => new TreatmentId(value)) { }
    //}

    //public class MemberIdConverter : ValueConverter<MemberToInvite, Guid>
    //{
    //    public MemberIdConverter()
    //        : base(id => id.Value, value => new MemberToInvite(value)) { }
    //}
    ////public class WorkFileIdConverter : ValueConverter<WorkFileId, Guid>
    ////{
    ////    public WorkFileIdConverter()
    ////        : base(id => id.Value, value => new WorkFileId(value)) { }
    ////}

    //public class BlobFileIdConverter : ValueConverter<BlobFile, Guid>
    //{
    //    public BlobFileIdConverter()
    //        : base(id => id.Value, value => new BlobFile(value)) { }
    //}
}
