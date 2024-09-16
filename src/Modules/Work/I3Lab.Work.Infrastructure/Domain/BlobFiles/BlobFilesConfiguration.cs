using I3Lab.Works.Domain.BlobFiles;
using I3Lab.Works.Domain.Works;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Infrastructure.Domain.BlobFiles
{
    public class BlobFileConfiguration : IEntityTypeConfiguration<BlobFile>
    {
        public void Configure(EntityTypeBuilder<BlobFile> builder)
        {
            builder.HasKey(bf => bf.Id);

            builder.Property(bf => bf.WorkId).IsRequired();
            builder.Property(bf => bf.BlobName).IsRequired(false);
            builder.Property(bf => bf.FileName).IsRequired(false);
            builder.Property(bf => bf.BlobDirectoryName).IsRequired(false);

            builder.OwnsOne(bf => bf.Path);

            builder.OwnsOne(bf => bf.ContentType, b =>
            {
                b.Property(a => a.Value).HasColumnName("ContentType").IsRequired(false);
            });

            builder.OwnsOne(bf => bf.Url, b =>
            {
                b.Property(a => a.Value).HasColumnName("Url").IsRequired();
            });

            //builder.OwnsOne(bf => bf.Path, path =>
            //{
            //    path.Property(p => p.ContainerName).HasColumnName("ContainerName");
            //    path.Property(p => p.BlobDirectoryName).HasColumnName("BlobDirectoryName");
            //    path.Property(p => p.FileName).HasColumnName("FileName");
            //});

            //builder.Property(bf => bf.Path).HasColumnName("BlobFilePath").IsRequired();
            builder.Property(bf => bf.CreateDate).IsRequired();


            builder.OwnsOne(bf => bf.Accessibilitylevel, b =>
            {
                b.Property(a => a.Value).HasColumnName("Accessibilitylevel").IsRequired();
            });

            builder.OwnsOne(bf => bf.FileType, b =>
            {
                b.Property(ft => ft.Value).HasColumnName("FileType").IsRequired();
            });
        }
    }
}
