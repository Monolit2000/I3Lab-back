

namespace I3Lab.User.Application.Contract
{
    public interface IPasswordHasher
    {
        public string Generate(string password);
    }
}
