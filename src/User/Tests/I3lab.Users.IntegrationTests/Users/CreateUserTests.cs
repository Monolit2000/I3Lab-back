using FluentAssertions;
using I3lab.Users.IntegrationTests.Abstraction;
using I3Lab.Users.Application.Register;
using I3Lab.Users.Domain.Users;
using System.Data.Entity;


namespace I3lab.Users.IntegrationTests.Users
{
    public class CreateUserTests : BaseIntegrationTest
    {
        public CreateUserTests(IntegrationTestWebAppFactory factory) 
            : base(factory)
        {
        }

        [Fact]
        public async Task Handle_Should_CreateUser_WhenCommandIsValid()
        {
            // Arrange 
            var command = new RegisterUserCommand(Faker.Internet.Email(), Faker.Internet.Password(), Faker.Internet.Avatar());

            //Act
            var result = await Sender.Send(command);

            //Assert
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Handle_Should_AddUserToDatabase_WhenCommandIsValid()
        {
            // Arrange 
            var command = new RegisterUserCommand(Faker.Internet.Email(), Faker.Internet.Password(), Faker.Internet.Avatar());

            //Act
            var result = await Sender.Send(command);

            //Assert
            User? user = DbContext.Users.FirstOrDefault(u =>
            u.UserId == new UserId(result.Value.UserId));

            user.Should().NotBeNull();
        }
    }
}
