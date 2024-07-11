using I3Lab.BuildingBlocks.Domain;

namespace I3Lab.Users.Domain.Users
{
    public class User : Entity, IAggregateRoot
    {
        public UserId Id { get; private set; }
        public string AvatarImage { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public DateTime RegisterDate { get; private set; }

        // Private constructor for EF Core
        private User() { }

        private User(
            string name,
            string lastName,
            string email, 
            string passwordHash, 
            string avatarImage)
        {
            Id = new UserId(Guid.NewGuid());
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

        public void UpdateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty.", nameof(name));
            Name = name;
        }

        public void UpdateLastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name cannot be empty.", nameof(lastName));
            LastName = lastName;
        }

        public void UpdateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be empty.", nameof(email));
            Email = email;
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
