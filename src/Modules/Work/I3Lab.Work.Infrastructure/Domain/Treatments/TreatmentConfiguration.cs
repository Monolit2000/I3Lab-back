using I3Lab.Works.Domain.Treatments;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace I3Lab.Works.Infrastructure.Domain.Treatments
{
    public class TreatmentConfiguration : IEntityTypeConfiguration<Treatment>
    {
        public void Configure(EntityTypeBuilder<Treatment> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Titel)
                .IsRequired();

            builder.HasMany(e => e.TreatmentStages)
                   .WithOne()
                   .HasForeignKey(e => e.Treatment.Id);

            builder.HasMany(e => e.TreatmentMemberss)
                 .WithOne()
                 .HasForeignKey(e => e.TreatmentId)
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
