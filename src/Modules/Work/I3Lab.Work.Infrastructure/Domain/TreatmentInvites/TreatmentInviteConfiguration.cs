using I3Lab.Works.Domain.TreatmentInvites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace I3Lab.Works.Infrastructure.Domain.TreatmentInvites
{
    public class TreatmentInviteConfiguration : IEntityTypeConfiguration<TreatmentInvite>
    {
        public void Configure(EntityTypeBuilder<TreatmentInvite> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.MemberToInvite)
                   .WithMany()
                   .HasForeignKey("MemberToInviteId") 
                   .IsRequired();

            builder.HasOne(e => e.Inviter)
                   .WithMany()
                   .HasForeignKey("InviterId") 
                   .IsRequired();

            builder.HasOne(e => e.Treatment)
                   .WithMany()
                   .HasForeignKey("TreatmentId") 
                   .IsRequired();

            builder.OwnsOne(e => e.TreatmentInviteStatus, b =>
            {
                b.Property(t => t.Value)
                 .HasColumnName("Status")
                 .IsRequired();
            });


            builder.Property(e => e.OcurredOn);

            //builder.Property(e => e.OcurredOn)
            //       .IsRequired()
            //       .HasColumnType("OcurredOn");

        }
    }
}
