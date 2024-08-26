using I3Lab.Doctors.Domain.Doctors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace I3Lab.Doctors.Infrastructure.Domain.Doctors
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(d => d.Id);

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

            builder.OwnsOne(d => d.Email, avatar =>
            {
                avatar.Property(a => a.Value).HasColumnName("Email"); 
            });

            builder.OwnsOne(d => d.DoctorAvatar, avatar =>
            {
                avatar.Property(a => a.Url)
                      .HasColumnName("DoctorAvatarUrl");
                //.IsRequired();
            });

            //builder.Property(d => d.ConfirmationStatus)
            //    .HasConversion(
            //        status => status.ToString(),
            //        status => ConfirmationStatus.Create(status).Value)
            //    .IsRequired();


     
        }
    }
}
