using Azure;
using I3Lab.Doctors.Domain.Doctors;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using I3Lab.Doctors.Domain.DoctorCreationProposals;

namespace I3Lab.Doctors.Infrastructure.Domain.DoctorCreationProposals
{
    public class DoctorCreationProposalConfiguration : IEntityTypeConfiguration<DoctorCreationProposal>
    {
        public void Configure(EntityTypeBuilder<DoctorCreationProposal> builder)
        {
            builder.HasKey(p => p.Id);

            //builder.OwnsOne(p => p.Name);
            //builder.OwnsOne(p => p.Email);
            //builder.OwnsOne(p => p.DoctorAvatar);

            builder.OwnsOne(d => d.Name, avatar =>
            {
                avatar.Property(a => a.FirstName);
                avatar.Property(a => a.LastName);
                //.IsRequired();
            });

            builder.OwnsOne(d => d.Email, avatar =>
            {
                avatar.Property(a => a.Value)
                      .HasColumnName("Email");
                //.IsRequired();
            });

            builder.OwnsOne(d => d.DoctorAvatar, avatar =>
            {
                avatar.Property(a => a.Url)
                      .HasColumnName("DoctorAvatarUrl");
                      //.IsRequired();
            });

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.ConfirmationStatus)
                .HasConversion(
                    status => status.ToString(),
                    status => (ConfirmationStatus)Enum.Parse(typeof(ConfirmationStatus), status))
                .IsRequired();
        }
    }
}
