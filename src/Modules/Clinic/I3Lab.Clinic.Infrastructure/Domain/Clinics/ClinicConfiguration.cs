using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using I3Lab.Clinics.Domain.Clinics;

namespace I3Lab.Clinics.Infrastructure.Domain.Clinics
{
    public class ClinicConfiguration : IEntityTypeConfiguration<Clinic>
    {
        public void Configure(EntityTypeBuilder<Clinic> builder)
        {
            builder.HasKey(c => c.Id);

            builder.OwnsOne(c => c.Address, ca =>
            {
                ca.Property(c => c.Value).HasColumnName("ClinicAddress").IsRequired();
            });

            builder.OwnsOne(c => c.ClinicName, cn =>
            {
                cn.Property(c => c.Value).HasColumnName("ClinicName").IsRequired();
            });

            builder.OwnsOne(c => c.Status, cs =>
            {
                cs.Property(s => s.Value).HasColumnName("ClinicStatus").IsRequired();
            });

            builder.Property(c => c.CreatedAt)
                   .HasColumnName("CreatedAt")
                   .IsRequired();

            builder.HasMany(c => c.Doctors)
                .WithOne()
                .HasForeignKey(dc => dc.ClinicId);
        }
    }
}
//builder.OwnsMany(c => c.Doctors, b =>
//{
//    b.ToTable("Doctors");
//    b.HasKey(x => x.DoctorId);
//    b.WithOwner().HasForeignKey(x => x.ClinicId);
//    b.Property(x => x.AddedAt).IsRequired();
//});