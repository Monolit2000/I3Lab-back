using I3Lab.Works.Domain.Treatments;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;


namespace I3Lab.Works.Infrastructure.Domain.Treatments
{
    public class TreatmentConfiguration : IEntityTypeConfiguration<Treatment>
    {
        public void Configure(EntityTypeBuilder<Treatment> builder)
        {
            builder.HasKey(e => e.Id);


            builder.HasMany(e => e.TreatmentStages)
                   .WithOne();

            //builder.HasMany(e => e.TreatmentMemberss)
            //     .WithOne()
            //     .HasForeignKey(e => e.TreatmentId)
            //     .OnDelete(DeleteBehavior.Cascade);

            builder.OwnsOne(t => t.TreatmentDate);

            builder.OwnsOne(e => e.Titel, b =>
            {
                b.Property(t => t.Value).HasColumnName("Titel").IsRequired();
            });

            builder.OwnsMany(e => e.TreatmentMemberss, b =>
            {
                // b.HasKey(wm => new { wm.TreatmentId, wm.Member });

                b.HasKey(wm => wm.Id).HasName("sdfsdfsdf");

                b.HasOne(vm => vm.Member)
                .WithOne();

                b.HasOne(vm => vm.AddedBy)
                .WithOne();

                b.Property(wm => wm.TreatmentId).IsRequired();

                //b.OwnsOne(o => o.TreatmentId, b =>
                //{
                //    b.Property(a => a.Value).HasColumnName("TreatmentId").IsRequired();
                //});

               // b.Property(wm => wm.Member).IsRequired();
               // b.Property(wm => wm.AddedBy).IsRequired();
                b.Property(wm => wm.JoinDate).IsRequired();

                b.OwnsOne(at => at.AccessibilityType, b =>
                {
                    b.Property(a => a.Value).HasColumnName("AccessibilityType");
                });

                // Уникальный индекс для WorkMember
                // b.HasIndex(wm => new { wm.TreatmentId, wm.Member }).IsUnique();
                b.HasIndex(wm => wm.TreatmentId);
            });
        }
    }
}
