using Microsoft.EntityFrameworkCore;
using I3Lab.Modules.BlobFailes.Domain.BlobFiles;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace I3Lab.Modules.BlobFailes.Infrastructure.Domain.BlobFiles
{
    public class BlobFileConfiguration : IEntityTypeConfiguration<BlobFile>
    {
        public void Configure(EntityTypeBuilder<BlobFile> builder)
        {
            builder.ToTable("BlobFiles");

            builder.HasKey(bf => bf.Id);

            builder.Property(bf => bf.CreateDate).IsRequired();


            builder.OwnsOne(bf => bf.Path);

            builder.OwnsOne(bf => bf.ContentType, b =>
            {
                b.Property(a => a.Value).HasColumnName("ContentType").IsRequired(false);
            });

            builder.OwnsOne(bf => bf.Url, b =>
            {
                b.Property(a => a.Value).HasColumnName("Url").IsRequired();
            });

            builder.OwnsOne(bf => bf.Accessibilitylevel, b =>
            {
                b.Property(a => a.Value).HasColumnName("Accessibilitylevel").IsRequired();
            });
        }
    }
}
