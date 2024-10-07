using I3Lab.Clinics.Domain.Clinics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace I3Lab.Clinics.Infrastructure.Domain.Clinics
{
    public class ClinicCreationProposalConfiguration : IEntityTypeConfiguration<ClinicCreationProposal>
    {
        public void Configure(EntityTypeBuilder<ClinicCreationProposal> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.CreatedAt).HasColumnName("CreatedAt").IsRequired();

            builder.OwnsOne(c => c.ClinicName, cn =>
            {
                cn.Property(c => c.Value).HasColumnName("ClinicName").IsRequired();
            });

            builder.OwnsOne(c => c.Address, ca =>
            {
                ca.Property(c => c.Value).HasColumnName("ClinicAddress").IsRequired();
            });

            builder.OwnsOne(c => c.ConfirmationStatus, cs =>
            {
                cs.Property(s => s.Value).HasColumnName("ConfirmationStatus").IsRequired();
            });

        }
    }
}
