using I3Lab.Users.Domain.Users;
using Microsoft.EntityFrameworkCore;
using I3Lab.Users.Infrastructure.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace I3Lab.Users.Infrastructure.Persistence
{
    public class UserContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }

        public UserContext(DbContextOptions<UserContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("User");

            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

    }
}
