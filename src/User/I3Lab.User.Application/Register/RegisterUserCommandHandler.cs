using FluentResults;
using I3Lab.Users.Application.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Users.Application.Register
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Result<RegisterDto>>
    {
        private readonly IPasswordHasher _passwordHasher;

        public RegisterUserCommandHandler(IPasswordHasher passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }
        public async Task<Result<RegisterDto>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var hashPassword = _passwordHasher.Generate(request.Password);

            return new RegisterDto();
        }
    }
}
