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
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AvatarImage { get; set; }

        public RegisterUserCommand(
            string name,
            string lastName, 
            string email,
            string password, 
            string avatarImage = null)
        {
            Name = name;
            LastName = lastName;
            Email = email;
            Password = password;
            AvatarImage = avatarImage;
        }
    }
}
