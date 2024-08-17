using I3Lab.Users.Domain.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace I3Lab.Users.Infrastructure.Domain
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.UserId)
                .HasConversion(new UserIdConverter()).IsRequired(false);

            builder.Property(e => e.AvatarImage).IsRequired(false);
            builder.Property(e => e.Name).IsRequired(false);
            builder.Property(e => e.LastName).IsRequired(false);
            builder.Property(e => e.Email).IsRequired();
            builder.Property(e => e.PasswordHash).IsRequired();
            builder.Property(e => e.RegisterDate).IsRequired();

           // builder.HasMany<IdentityUserClaim<string>>()
           //.WithOne()
           //.HasForeignKey(uc => uc.UserId)
           //.HasPrincipalKey(u => u.Id);
        }
    }
}
