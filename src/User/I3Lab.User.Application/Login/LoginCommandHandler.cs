using FluentResults;
using I3Lab.Users.Application.Contract;
using I3Lab.Users.Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Users.Application.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<LoginDto>>
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public LoginCommandHandler(
            IPasswordHasher passwordHasher,
            IUserRepository userRepository,
            IJwtService jwtService)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _jwtService = jwtService;   
        }

        public async Task<Result<LoginDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);

            var result = _passwordHasher.Verify(request.Password, user.PasswordHash);

            if (result is false)
                return Result.Fail("password error");

            var token = _jwtService.GenegateToken(user);

            return new LoginDto(token);
        }
    }
}
