using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using I3Lab.Works.Domain.Works;


namespace I3Lab.Works.Infrastructure.Domain.Works
{
    public class WorkEntityTypeConfiguration : IEntityTypeConfiguration<Work>
    {
        public void Configure(EntityTypeBuilder<Work> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasMany(e => e.WorkFiles)
                .WithOne()
                .HasForeignKey(f => f.WorkId);

            builder.HasMany(e => e.WorkMembers)
                .WithOne()
                .HasForeignKey(m => m.WorkId);
        }
    }
}
