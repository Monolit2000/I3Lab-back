using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using I3Lab.Works.Domain.Works;
using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.Treatment;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using I3Lab.Works.Domain.BlobFiles;


namespace I3Lab.Works.Infrastructure.Domain.Works
{
    public class WorkConfiguration : IEntityTypeConfiguration<Work>
    {
        public void Configure(EntityTypeBuilder<Work> builder)
        {
            // Установка ключа для Work
            builder.HasKey(e => e.Id);

            // Конвертеры для идентификаторов
            //builder.Property(e => e.Id).HasConversion<WorkIdConverter>();


            builder.Property(e => e.TreatmentId).IsRequired();

            builder.Property(e => e.CreatorId).IsRequired();

            builder.Property(e => e.CustomerId).IsRequired();


            //Конфигурация WorkFile
            builder.HasMany(e => e.WorkFiles)
                .WithOne()
                .HasForeignKey(f => f.WorkId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            //builder.OwnsMany(e => e.WorkFiles, b =>
            //{

            //    b.HasKey(wf => wf.FileId);

            //    b.Property(wf => wf.FileId)
            //        .HasConversion<BlobFileIdConverter>()
            //        .IsRequired();

            //    b.Property(wf => wf.WorkId)
            //        .HasConversion<WorkIdConverter>()
            //        .IsRequired();

            //    b.HasIndex(wf => new { wf.WorkId, wf.FileId }).IsUnique();
            //});




            //builder.HasMany(e => e.WorkMembers)
            //    .WithOne()
            //    .HasForeignKey(m => m.WorkId)
            //    .OnDelete(DeleteBehavior.Cascade)
            //    .IsRequired();

            builder.OwnsMany(e => e.WorkMembers, b =>
            {
                b.HasKey(wm => new { wm.WorkId, wm.MemberId });


                b.Property(wm => wm.WorkId).IsRequired();

                //b.OwnsOne(o => o.WorkId, b =>
                //{
                //    b.Property(a => a.Value).HasColumnName("WorkId").IsRequired();
                //});

                b.Property(wm => wm.MemberId).IsRequired();
                b.Property(wm => wm.AddedBy).IsRequired();
                b.Property(wm => wm.JoinDate).IsRequired();

                b.OwnsOne(at => at.AccessibilityType, b =>
                {
                    b.Property(a => a.Value).HasColumnName("AccessibilityType");
                });

                // Уникальный индекс для WorkMember
                b.HasIndex(wm => new { wm.WorkId, wm.MemberId }).IsUnique();
            });

            // Настройка других свойств
            builder.Property(e => e.WorkStartedDate).IsRequired();

            builder.ComplexProperty(o => o.WorkStatus, b =>
            {
                b.IsRequired();
                b.Property(a => a.Value).HasColumnName("WorkStatus");
            });
        }
    }

    //public class WorkIdConverter : ValueConverter<WorkId, Guid>
    //{
    //    public WorkIdConverter()
    //        : base(id => id.Value, value => new WorkId(value)) { }
    //}

    //public class TreatmentIdConverter : ValueConverter<TreatmentId, Guid>
    //{
    //    public TreatmentIdConverter()
    //        : base(id => id.Value, value => new TreatmentId(value)) { }
    //}

    //public class MemberIdConverter : ValueConverter<MemberId, Guid>
    //{
    //    public MemberIdConverter()
    //        : base(id => id.Value, value => new MemberId(value)) { }
    //}
    ////public class WorkFileIdConverter : ValueConverter<WorkFileId, Guid>
    ////{
    ////    public WorkFileIdConverter()
    ////        : base(id => id.Value, value => new WorkFileId(value)) { }
    ////}

    //public class BlobFileIdConverter : ValueConverter<BlobFileId, Guid>
    //{
    //    public BlobFileIdConverter()
    //        : base(id => id.Value, value => new BlobFileId(value)) { }
    //}
}
