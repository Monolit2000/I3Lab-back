using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using I3Lab.Clinics.Domain.Doctors;
using I3Lab.Clinics.Domain.Clinics;

namespace I3Lab.Clinics.Infrastructure.Domain.Clinics
{
    public class ClinicConfiguration : IEntityTypeConfiguration<Clinic>
    {
        public void Configure(EntityTypeBuilder<Clinic> builder)
        {
            builder.HasKey(c => c.Id);

            // Настройка ClinicName как ValueObject
            builder.OwnsOne(c => c.ClinicName, cn =>
            {
                cn.Property(c => c.Name).HasColumnName("ClinicName").IsRequired();
            });

            // Настройка ClinicAddress как ValueObject
            builder.OwnsOne(c => c.Address, ca =>
            {
                ca.Property(c => c.Value).HasColumnName("ClinicAddress").IsRequired();
            });

            // Настройка ClinicStatus как ValueObject
            builder.OwnsOne(c => c.Status, cs =>
            {
                cs.Property(s => s.Value).HasColumnName("ClinicStatus").IsRequired();
            });

            // Настройка отношения с докторами
            //builder.HasMany<DoctorId>(c => c.ClinicDoctors)
            //    .WithMany()
            //    .UsingEntity(j => j.ToTable("ClinicDoctors"));

            // Настройка CreatedAt как обязательного поля
            builder.Property(c => c.CreatedAt)
                   .HasColumnName("CreatedAt")
                   .IsRequired();
        }
    }
}
