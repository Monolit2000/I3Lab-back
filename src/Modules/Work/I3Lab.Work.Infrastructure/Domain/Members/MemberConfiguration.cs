using I3Lab.Treatments.Domain.Members;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using I3Lab.Treatments.Infrastructure.Domain.Works;


namespace I3Lab.Treatments.Infrastructure.Domain.Members
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Email)
                .IsRequired();

            builder.ComplexProperty(o => o.MemberRole, roleBuilder =>
            {
                roleBuilder.IsRequired();
                roleBuilder.Property(p => p.Value).HasColumnName("MemberRole");
            });

            builder.Property(m => m.ClinicId).IsRequired(false);

            builder.Property(e => e.FirstName).IsRequired(false);

            builder.Property(e => e.LastName).IsRequired(false);
        }
    }
}