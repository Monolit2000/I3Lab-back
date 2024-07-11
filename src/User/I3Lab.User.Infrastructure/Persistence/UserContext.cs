using I3Lab.Users.Domain.Users;
using Microsoft.EntityFrameworkCore;
using I3Lab.Users.Infrastructure.Domain;

namespace I3Lab.Users.Infrastructure.Persistence
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

    }
}
