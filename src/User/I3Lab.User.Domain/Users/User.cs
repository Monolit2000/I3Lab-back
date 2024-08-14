using I3Lab.BuildingBlocks.Domain;
using Microsoft.AspNetCore.Identity;

namespace I3Lab.Users.Domain.Users
{
    public class User : IdentityUser, IAggregateRoot
    {
        //public UserId Id { get; private set; }

        public UserId UserId { get; private set; }
        public new string Id { get; private set; } = Guid.NewGuid().ToString();

        public string AvatarImage { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public DateTime RegisterDate { get; private set; }

        // Private constructor for EF Core
        //private User() { }

        public User() { }

        private User(
            string name,
            string lastName,
            string email, 
            string passwordHash, 
            string avatarImage)
        {
            UserId = new UserId(Guid.Parse(Id));
            Name = name;
            LastName = lastName;
            Email = email;
            PasswordHash = passwordHash;
            AvatarImage = avatarImage;
            RegisterDate = DateTime.UtcNow;
        }

        public static User Create(
            string name, 
            string lastName, 
            string email,
            string passwordHash, 
            string avatarImage = null)
        {
            return new User(
                name,
                lastName, 
                email, 
                passwordHash, 
                avatarImage);
        }

        public void UpdateName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("Name cannot be empty.", nameof(newName));
            Name = newName;
        }

        public void UpdateLastName(string newLastName)
        {
            if (string.IsNullOrWhiteSpace(newLastName))
                throw new ArgumentException("Last name cannot be empty.", nameof(newLastName));
            LastName = newLastName;
        }

        public void UpdateEmail(string newEmail)
        {
            if (string.IsNullOrWhiteSpace(newEmail))
                throw new ArgumentException("Email cannot be empty.", nameof(newEmail));
            Email = newEmail;
        }

        public void UpdatePasswordHash(string passwordHash)
        {
            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new ArgumentException("Password hash cannot be empty.", nameof(passwordHash));
            PasswordHash = passwordHash;
        }

        public void UpdateAvatarImage(string avatarImage)
        {
            AvatarImage = avatarImage;
        }
    }
}
