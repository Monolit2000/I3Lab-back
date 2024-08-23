using FluentResults;
using I3Lab.Users.Application.Contract;
using I3Lab.Users.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;


namespace I3Lab.Users.Application.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<LoginDto>>
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginCommandHandler(
            IPasswordHasher passwordHasher,
            IUserRepository userRepository,
            IJwtService jwtService,
            IHttpContextAccessor httpContextAccessor)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _jwtService = jwtService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Result<LoginDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);

            if (user == null)
                return Result.Fail("User not found");
                
            var result = _passwordHasher.Verify(request.Password, user.PasswordHash);

            if (result is false)
                return Result.Fail("password error");

            var token = _jwtService.GenegateToken(user);

            return new LoginDto(token);
        }

        private RefrashToken GenearateRefrashToken()
        {
            var refrashToken = new RefrashToken()
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(7)
            };

            return refrashToken;
        }

        private void SetRefrashToken(RefrashToken newRefrashToken)
        {
            var coockieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = newRefrashToken.Expires
            };

            _httpContextAccessor.HttpContext.Response.Cookies.Append(
                "refrash-Token", 
                newRefrashToken.Token, 
                coockieOptions);
        }
    }
}
