using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Users.Application.Register
{
    public class RegisterUserCommand : IRequest<Result<RegisterDto>>
    {

        public string Email { get; set; }
        public string Password { get; set; }

        public RegisterUserCommand(
            string email,
            string password)
        {
            Email = email;
            Password = password;
        }
    }
}
