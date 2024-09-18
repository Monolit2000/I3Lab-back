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

            builder.OwnsOne(d => d.Name, avatar =>
            {
                avatar.Property(a => a.FirstName);
                avatar.Property(a => a.LastName);
                //.IsRequired();
            });

            builder.OwnsOne(d => d.PhoneNumber, phoneNumber =>
            {
                phoneNumber.Property(a => a.Value).HasColumnName("PhoneNumber").IsRequired();
            });

            builder.OwnsOne(d => d.Email, a =>
            {
                a.Property(a => a.Value)
                      .HasColumnName("Emailll");
                //.IsRequired();
            });

            builder.OwnsOne(d => d.DoctorAvatar, avatar =>
            {
                avatar.Property(a => a.Url)
                      .HasColumnName("DoctorAvatarUrl");
                      //.IsRequired();
            });

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.OwnsOne(d => d.ConfirmationStatus, status =>
            {
                status.Property(s => s.Value).HasColumnName("ConfirmationStatuss").IsRequired();
            });

            //builder.Property(p => p.ConfirmationStatus)
            //    .HasConversion(
            //        status => status.ToString(),
            //        status => (ConfirmationStatus)Enum.Parse(typeof(ConfirmationStatus), status))
            //    .IsRequired();
        }
    }
}
