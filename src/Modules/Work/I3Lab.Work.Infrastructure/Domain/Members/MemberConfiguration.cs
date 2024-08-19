using I3Lab.Works.Domain.Members;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using I3Lab.Works.Infrastructure.Domain.Works;


namespace I3Lab.Works.Infrastructure.Domain.Members
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(e => e.Id);

            //builder.Property(e => e.Id).HasConversion<MemberIdConverter>();

            builder.Property(e => e.Login)
                .IsRequired();

            builder.Property(e => e.Email)
                .IsRequired();

            //builder.OwnsOne(o => o.MemberRole, roleBuilder =>
            //{
            //    roleBuilder.Property(r => r.Value).HasColumnName("MemberRole").IsRequired();
            //});

            builder.ComplexProperty(o => o.MemberRole, roleBuilder =>
            {
                roleBuilder.IsRequired();
                roleBuilder.Property(p => p.Value).HasColumnName("MemberRole");
            });

            builder.Property(e => e.FirstName)
                .IsRequired();

            builder.Property(e => e.LastName)
                .IsRequired();
        }
    }
}