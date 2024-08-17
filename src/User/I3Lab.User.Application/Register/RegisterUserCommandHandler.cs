using FluentResults;
using I3Lab.Users.Application.Contract;
using I3Lab.Users.Domain.Users;
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
        private readonly IUserRepository _userRepository; 

        public RegisterUserCommandHandler(
            IPasswordHasher passwordHasher,
            IUserRepository userRepository)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;   
        }
        public async Task<Result<RegisterDto>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var hashPassword = _passwordHasher.Generate(request.Password);

            var user = User.Create(
                request.Email, 
                hashPassword);

            await _userRepository.AddAsync(user);

            return new RegisterDto();
        }
    }
}
