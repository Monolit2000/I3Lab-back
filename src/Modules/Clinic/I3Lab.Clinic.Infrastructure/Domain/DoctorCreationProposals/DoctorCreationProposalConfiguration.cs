using Microsoft.EntityFrameworkCore;
using I3Lab.Clinics.Domain.DoctorCreationProposals;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace I3Lab.Clinics.Infrastructure.Domain.DoctorCreationProposals
{
    public class DoctorCreationProposalConfiguration : IEntityTypeConfiguration<DoctorCreationProposal>
    {
        public void Configure(EntityTypeBuilder<DoctorCreationProposal> builder)
        {
            builder.HasKey(p => p.Id);

            builder.OwnsOne(d => d.Name, avatar =>
            {
                avatar.Property(a => a.FirstName);
                avatar.Property(a => a.LastName);
            });

            builder.OwnsOne(d => d.PhoneNumber, phoneNumber =>
            {
                phoneNumber.Property(a => a.Value).HasColumnName("PhoneNumber").IsRequired();
            });

            builder.OwnsOne(d => d.Email, a =>
            {
                a.Property(a => a.Value).HasColumnName("Emailll");
            });

            builder.OwnsOne(d => d.DoctorAvatar, avatar =>
            {
                avatar.Property(a => a.Url).HasColumnName("DoctorAvatarUrl");
            });

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.OwnsOne(d => d.ConfirmationStatus, status =>
            {
                status.Property(s => s.Value).HasColumnName("ConfirmationStatuss").IsRequired();
            });
        }
    }
}
