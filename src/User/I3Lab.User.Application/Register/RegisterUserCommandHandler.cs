using FluentResults;
using I3Lab.Users.Application.Contract;
using I3Lab.Users.Domain.Users;
using MediatR;
using FluentEmail.Core;

namespace I3Lab.Users.Application.Register
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Result<RegisterDto>>
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _userRepository;
        private readonly IFluentEmail _fluentEmail;

        public RegisterUserCommandHandler(
            IPasswordHasher passwordHasher,
            IUserRepository userRepository,
            IFluentEmail fluentEmail)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _fluentEmail = fluentEmail;
        }
        public async Task<Result<RegisterDto>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var userExist = await _userRepository.GetByEmailAsync(request.Email);

            if (userExist != null)
                return Result.Fail("User already exist");

            var hashPassword = _passwordHasher.Generate(request.Password);

            var user = User.CreateNew(
                request.Email, 
                hashPassword,
                request.AvatarImage);

            await _userRepository.AddAsync(user);

            await _fluentEmail
                .To(user.Email)
                .Subject("Email verification")
                .Body("To verify your email click here")
                .SendAsync();

            return new RegisterDto() {UserId = user.UserId.Value };
        }
    }
}
