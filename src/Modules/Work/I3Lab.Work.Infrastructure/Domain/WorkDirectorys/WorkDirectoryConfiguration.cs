using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using I3Lab.Works.Domain.WorkDirectorys;

namespace I3Lab.Works.Infrastructure.Domain.WorkDirectorys
{
    public class WorkDirectoryConfiguration : IEntityTypeConfiguration<WorkDirectory>
    {
        public void Configure(EntityTypeBuilder<WorkDirectory> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasMany(e => e.Files3Ds)
                .WithOne()
                .HasForeignKey(f => f.WorkDirectoryId);

            builder.HasMany(e => e.OtherFiles)
                .WithOne()
                .HasForeignKey(f => f.WorkDirectoryId);
        }
    }
}
