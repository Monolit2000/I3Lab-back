﻿using AutoFixture;
using FluentAssertions;
using I3Lab.Users.Application.Register;
using I3Lab.Users.Application.Contract;
using I3Lab.Users.Domain.Users;
using NSubstitute;
using Xunit;


namespace I3lab.Users.Tests.Users
{
    public class RegisterUserCommandHandlerTests
    {
        private readonly IFixture _fixture;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _userRepository;
        private readonly RegisterUserCommandHandler _handler;

        public RegisterUserCommandHandlerTests()
        {
            _fixture = new Fixture();
            _passwordHasher = Substitute.For<IPasswordHasher>();
            _userRepository = Substitute.For<IUserRepository>();
            _handler = new RegisterUserCommandHandler(_passwordHasher, _userRepository);
        }

        [Fact]
        public async Task Handle_ShouldReturnFail_WhenUserAlreadyExists()
        {
            // Arrange
            var command = _fixture.Create<RegisterUserCommand>();
            _userRepository.GetByEmailAsync(command.Email).Returns(Task.FromResult(new User()));

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == "User already exist");
        }

        [Fact]
        public async Task Handle_ShouldRegisterUser_WhenUserDoesNotExist()
        {
            // Arrange
            var command = _fixture.Create<RegisterUserCommand>();
            var hashedPassword = _fixture.Create<string>();
            _userRepository.GetByEmailAsync(command.Email).Returns(Task.FromResult<User>(null));
            _passwordHasher.Generate(command.Password).Returns(hashedPassword);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeTrue();
            await _userRepository.Received(1).AddAsync(Arg.Is<User>(u =>
                u.Email == command.Email && u.PasswordHash == hashedPassword));
        }

        [Fact]
        public async Task Handle_ShouldReturnRegisterDto_WhenUserIsRegistered()
        {
            // Arrange
            var command = _fixture.Create<RegisterUserCommand>();
            _userRepository.GetByEmailAsync(command.Email).Returns(Task.FromResult<User>(null));
            _passwordHasher.Generate(command.Password).Returns(_fixture.Create<string>());

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().BeOfType<RegisterDto>();
        }
    }
}