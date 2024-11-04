using FluentAssertions;
using I3lab.Users.IntegrationTests.Abstraction;
using I3Lab.Users.Application.Login;
using I3Lab.Users.Domain.Users;
using NSubstitute;
using I3Lab.Users.Application.Contract;


namespace I3lab.Users.IntegrationTests.Users
{
    public class UserLoginTests : BaseIntegrationTest
    {
        //private readonly IPasswordHasher _passwordHasher;


        public UserLoginTests(IntegrationTestWebAppFactory factory)
            : base(factory)
        {
            //_passwordHasher = Substitute.For<IPasswordHasher>();
        }

        [Fact]
        public async Task Handle_Should_LoginUser_WhenCredentialsAreValid()
        {
            // Arrange
            var email = Faker.Internet.Email();
            var password = Faker.Internet.Password();

            var user = User.CreateNew(email, _passwordHasher.Generate(password), Faker.Internet.Avatar());
            DbContext.Users.Add(user);
            await DbContext.SaveChangesAsync();

            var command = new LoginCommand(email, password);

            // Act
            var result = await Sender.Send(command);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Token.Should().NotBeNullOrWhiteSpace();
        }

        //[Fact]
        //public async Task Handle_Should_Fail_When_User_Not_Found()
        //{
        //    // Arrange
        //    var command = new LoginCommand(Faker.Internet.Email(), Faker.Internet.Password());

        //    // Act
        //    var result = await Sender.Send(command);

        //    // Assert
        //    result.IsFailed.Should().BeTrue();
        //    result.Errors.Should().Contain(e => e.Message == "User not found");
        //}

        [Fact]
        public async Task Handle_Should_Fail_When_Password_Is_Incorrect()
        {
            // Arrange
            var email = Faker.Internet.Email();
            var user = User.CreateNew(email, _passwordHasher.Generate(Faker.Internet.Password()), Faker.Internet.Avatar());
            DbContext.Users.Add(user);
            await DbContext.SaveChangesAsync();

            var command = new LoginCommand(email, "wrong_password");

            // Act
            var result = await Sender.Send(command);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().Contain(e => e.Message == "password error");
        }

    }
}
