using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using FluentResults;
using I3Lab.Users.Application.Contract;
using I3Lab.Users.Domain.Users;
using I3Lab.Users.Application.Login;
using Microsoft.AspNetCore.Http;
using NSubstitute;
using Xunit;

namespace I3Lab.Users.Application.Tests.Login
{
    public class LoginCommandHandlerTests
    {
        private readonly IFixture _fixture;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly LoginCommandHandler _handler;

        public LoginCommandHandlerTests()
        {
            _fixture = new Fixture();
            _passwordHasher = Substitute.For<IPasswordHasher>();
            _userRepository = Substitute.For<IUserRepository>();
            _jwtService = Substitute.For<IJwtService>();
            _httpContextAccessor = Substitute.For<IHttpContextAccessor>();
            _handler = new LoginCommandHandler(
                _passwordHasher,
                _userRepository,
                _jwtService,
                _httpContextAccessor
            );
        }

        [Fact]
        public async Task Handle_Should_Return_Fail_When_User_Not_Found()
        {
            // Arrange
            var command = _fixture.Create<LoginCommand>();

            _userRepository.GetByEmailAsync(command.Email).Returns((User)null);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().Contain(e => e.Message == "User not found");
        }

        [Fact]
        public async Task Handle_Should_Return_Fail_When_Password_Is_Incorrect()
        {
            // Arrange
            var command = _fixture.Create<LoginCommand>();
            var user = _fixture.Create<User>();
            _userRepository.GetByEmailAsync(command.Email).Returns(user);
            _passwordHasher.Verify(command.Password, user.PasswordHash).Returns(false);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().Contain(e => e.Message == "password error");
        }

        [Fact]
        public async Task Handle_Should_Return_LoginDto_When_Login_Is_Successful()
        {
            // Arrange
            var command = _fixture.Create<LoginCommand>();
            var user = _fixture.Create<User>();
            var token = _fixture.Create<string>();

            _userRepository.GetByEmailAsync(command.Email).Returns(user);
            _passwordHasher.Verify(command.Password, user.PasswordHash).Returns(true);
            _jwtService.GenegateToken(user).Returns(token);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Token.Should().Be(token);
        }
    }
}
