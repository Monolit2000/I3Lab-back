using I3Lab.Treatments.Domain.TreatmentFils;
using I3Lab.Treatments.Domain.TreatmentStages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Infrastructure.Domain.TreatmentFiles
{
    public class TreatmentFileConfiguration : IEntityTypeConfiguration<TreatmentFile>
    {
        public void Configure(EntityTypeBuilder<TreatmentFile> builder)
        {
            builder.ToTable("TreatmentFiles");

            builder.HasKey(bf => bf.Id);

            builder.Property(bf => bf.TreatmentStageId).IsRequired();

            builder.Property(bf => bf.TreatmentId).IsRequired(false);

            builder.OwnsOne(bf => bf.BlobFilePath);

            builder.OwnsOne(bf => bf.ContentType, b =>
            {
                b.Property(a => a.Value).HasColumnName("ContentType").IsRequired(false);
            });

            builder.OwnsOne(tf => tf.FilePreview, b =>
            {
                b.Property(a => a.Url).HasColumnName("PreviewUrl").IsRequired(false);
            });

            builder.OwnsOne(bf => bf.Url, b =>
            {
                b.Property(a => a.Value).HasColumnName("Url").IsRequired();
            });
      
            builder.Property(bf => bf.CreateDate).IsRequired();

            builder.OwnsOne(bf => bf.FileType, b =>
            {
                b.Property(ft => ft.Value).HasColumnName("FileType").IsRequired();
            });
        }
    }
}
