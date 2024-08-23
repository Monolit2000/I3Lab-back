using FluentResults;
using I3Lab.Users.Application.Contract;
using I3Lab.Users.Domain.Users;
using MediatR;

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
            var userExist = await _userRepository.GetByEmailAsync(request.Email);

            if (userExist != null)
                return Result.Fail("User already exist");

            var hashPassword = _passwordHasher.Generate(request.Password);

            var user = User.CreateNew(
                request.Email, 
                hashPassword,
                request.AvatarImage);

            await _userRepository.AddAsync(user);

            return new RegisterDto() {UserId = user.UserId.Value };
        }
    }
}
