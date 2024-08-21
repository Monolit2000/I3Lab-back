using I3Lab.Users.Application.Contract;


namespace I3Lab.Users.Infrastructure
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Generate(string password) =>
            BCrypt.Net.BCrypt.EnhancedHashPassword(password);

        public bool Verify(string password, string hashePassword) =>
            BCrypt.Net.BCrypt.EnhancedVerify(password, hashePassword);
    }
}
