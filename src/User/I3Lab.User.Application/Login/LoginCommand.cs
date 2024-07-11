using FluentResults;
using MediatR;

namespace I3Lab.Users.Application.Login
{
    public class LoginCommand : IRequest<Result<LoginDto>>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
