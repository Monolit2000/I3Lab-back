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
            // Установка ключа для BlobFile
            builder.HasKey(bf => bf.Id);

            // Конвертеры для идентификаторов
            builder.Property(bf => bf.Id).HasConversion<BlobFileIdConverter>();

            builder.Property(bf => bf.WorkId).HasConversion<WorkIdConverter>().IsRequired();

            builder.Property(bf => bf.BlobName).IsRequired();
            builder.Property(bf => bf.FileName).IsRequired();
            builder.Property(bf => bf.BlobDirectoryName).IsRequired();
            builder.Property(bf => bf.BlobFilePath).IsRequired();
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

    public class BlobFileIdConverter : ValueConverter<BlobFileId, Guid>
    {
        public BlobFileIdConverter()
            : base(id => id.Value, value => new BlobFileId(value)) { }
    }

    public class WorkIdConverter : ValueConverter<WorkId, Guid>
    {
        public WorkIdConverter()
            : base(id => id.Value, value => new WorkId(value)) { }
    }
}
