using I3Lab.Clinics.Domain.Doctors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Clinics.Infrastructure.Domain.Doctors
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
                avatar.Property(a => a.Url).HasColumnName("DoctorAvatarUrl");
                //.IsRequired();
            });

            builder.HasMany(d => d.Clinics)
                .WithOne() 
                .HasForeignKey(dc => dc.DoctorId);


        }
    }
}
