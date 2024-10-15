using I3Lab.Clinics.Domain.Clinics;
using I3Lab.Clinics.Domain.Doctors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace I3Lab.Clinics.Infrastructure.Domain.Clinics
{
    public class ClinicDoctorConfiguration : IEntityTypeConfiguration<ClinicDoctor>
    {
        public void Configure(EntityTypeBuilder<ClinicDoctor> builder)
        {
            builder.ToTable("ClinicDoctors");
          
            builder.HasKey(cd => new { cd.ClinicId, cd.DoctorId });

            builder.HasOne<Clinic>()
                .WithMany(c => c.ClinicDoctors)
                .HasForeignKey(cd => cd.ClinicId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<Doctor>()
                .WithMany(d => d.Clinics)
                .HasForeignKey(cd => cd.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(cd => cd.AddedAt)
                   .IsRequired();

            builder.Property(cd => cd.RemovedAt)
                   .IsRequired(false);

            builder.HasIndex(cd => cd.AddedAt); 
        }
    }
}
