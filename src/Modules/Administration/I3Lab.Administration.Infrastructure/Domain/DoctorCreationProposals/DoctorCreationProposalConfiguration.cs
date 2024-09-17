using I3Lab.Administration.Domain.DoctorCreationProposals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace I3Lab.Administration.Infrastructure.Domain.DoctorCreationProposals
{
    public class DoctorCreationProposalConfiguration : IEntityTypeConfiguration<DoctorCreationProposal>
    {
        public void Configure(EntityTypeBuilder<DoctorCreationProposal> builder)
        {
            builder.HasKey(p => p.Id); 

            builder.OwnsOne(d => d.Name, name =>
            {
                name.Property(n => n.FirstName)
                    .HasColumnName("FirstName")
                    .IsRequired();
                name.Property(n => n.LastName)
                    .HasColumnName("LastName")
                    .IsRequired();
            });

            builder.OwnsOne(d => d.PhoneNumber, phoneNumber =>
            {
                phoneNumber.Property(p => p.Value)
                           .HasColumnName("PhoneNumber")
                           .IsRequired();
            });

            builder.OwnsOne(d => d.Email, b =>
            {
                b.Property(e => e.Value)
                     .HasColumnName("Email")
                     .IsRequired();
            });

            builder.OwnsOne(d => d.DoctorAvatar, avatar =>
            {
                avatar.Property(a => a.Url)
                      .HasColumnName("DoctorAvatarUrl");
                //.IsRequired();
            });

            builder.Property(p => p.CreatedAt)
                   .IsRequired();

            builder.OwnsOne(d => d.ConfirmationStatus, status =>
            {
                status.Property(s => s.Value)
                      .HasColumnName("ConfirmationStatus")
                      .IsRequired();
            });
        }
    }
}
