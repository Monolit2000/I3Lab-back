using I3Lab.Treatments.Domain.Treatments;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;


namespace I3Lab.Treatments.Infrastructure.Domain.Treatments
{
    public class TreatmentConfiguration : IEntityTypeConfiguration<Treatment>
    {
        public void Configure(EntityTypeBuilder<Treatment> builder)
        {
            builder.HasKey(e => e.Id);


            //builder.HasMany(e => e.TreatmentStages)
            //       .WithOne();

            builder.OwnsOne(t => t.TreatmentDate);

            builder.OwnsOne(e => e.Titel, b =>
            {
                b.Property(t => t.Value).HasColumnName("TreatmentTitel").IsRequired();
            });

           builder.OwnsMany(e => e.TreatmentMembers, b =>
            {
                b.ToTable("TreatmentMembers");

                b.HasKey(wm => wm.Id);

                b.Property(wm => wm.TreatmentId).IsRequired();

                b.Property(wm => wm.JoinDate).IsRequired();

                b.Property(tm => tm.LeaveDate);

                b.HasOne(vm => vm.Member)
                  .WithMany() 
                  .HasForeignKey("MemberId") 
                  .IsRequired();

                b.HasOne(vm => vm.AddedBy)
                  .WithMany() 
                  .HasForeignKey("AddedById") 
                  .IsRequired();

                b.OwnsOne(at => at.AccessibilityType, b =>
                {
                    b.Property(a => a.Value).HasColumnName("AccessibilityType");
                });

                //b.HasIndex(wm => wm.TreatmentId);
            });
        }
    }
}
