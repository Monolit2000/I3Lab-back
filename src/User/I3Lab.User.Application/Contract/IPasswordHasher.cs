

namespace I3Lab.Users.Application.Contract
{
    public interface IPasswordHasher
    {
        public string Generate(string password);
    }
}
