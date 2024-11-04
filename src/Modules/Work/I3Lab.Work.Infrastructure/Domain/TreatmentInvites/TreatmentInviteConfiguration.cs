using I3Lab.Treatments.Domain.TreatmentInvites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace I3Lab.Treatments.Infrastructure.Domain.TreatmentInvites
{
    public class TreatmentInviteConfiguration : IEntityTypeConfiguration<TreatmentInvite>
    {
        public void Configure(EntityTypeBuilder<TreatmentInvite> builder)
        {
            builder.HasKey(e => e.Id);

           // builder.Property(e => e.InvitationToken).IsRequired(false);

            builder.OwnsOne(ti => ti.InviteToken, b =>
            {

                b.Property(t => t.Token)
                   .HasColumnName("InvitationToken")
                   .IsRequired(false);

                b.Property(t => t.ExpiryDate)
                    .HasColumnName("InviteTokenExpiryDate");
            });

            builder.HasOne(e => e.InvitedMember)
                   .WithMany()
                   .HasForeignKey("MemberToInviteId") 
                   .IsRequired();

            builder.HasOne(e => e.InviterMember)
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
