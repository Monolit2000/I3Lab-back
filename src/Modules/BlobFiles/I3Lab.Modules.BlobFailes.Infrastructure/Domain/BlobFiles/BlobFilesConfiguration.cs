using Microsoft.EntityFrameworkCore;
using I3Lab.Modules.BlobFailes.Domain.BlobFiles;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace I3Lab.Modules.BlobFailes.Infrastructure.Domain.BlobFiles
{
    public class BlobFileConfiguration : IEntityTypeConfiguration<BlobFile>
    {
        public void Configure(EntityTypeBuilder<BlobFile> builder)
        {
            builder.HasKey(bf => bf.Id);

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
