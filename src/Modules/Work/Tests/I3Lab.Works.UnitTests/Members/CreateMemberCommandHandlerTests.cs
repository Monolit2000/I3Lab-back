using FluentAssertions;
using I3Lab.Works.Application.Members.CreateMember;
using I3Lab.Works.Domain.Members;
using NSubstitute;
namespace I3Lab.Works.UnitTests.Members
{
    public class CreateMemberCommandHandlerTests
    {
        private readonly CreateMemberCommandHandler _handler;
        private readonly IMemberRepository _memberRepository;

        public CreateMemberCommandHandlerTests()
        {
            _memberRepository = Substitute.For<IMemberRepository>();
            _handler = new CreateMemberCommandHandler(_memberRepository);
        }

        [Fact]
        public async Task Handle_ShouldReturnError_WhenEmailIsTaken()
        {
            // Arrange
            var command = new CreateMemberCommand { Email = "test@example.com" };
            _memberRepository.IsEmailTakenAsync(command.Email).Returns(true);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == "Email is already taken");
        }

        [Fact]
        public async Task Handle_ShouldCreateNewMember_WhenEmailIsNotTaken()
        {
            // Arrange
            var command = new CreateMemberCommand { Email = "test@example.com" };
            _memberRepository.IsEmailTakenAsync(command.Email).Returns(false);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeTrue();
            await _memberRepository.Received(1).AddAsync(Arg.Any<Member>());
            await _memberRepository.Received(1).SaveChangesAsync();
        }

        [Fact]
        public async Task Handle_ShouldReturnMemberDto_WhenMemberIsCreated()
        {
            // Arrange
            var command = new CreateMemberCommand { Email = "test@example.com" };
            _memberRepository.IsEmailTakenAsync(command.Email).Returns(false);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().NotBeNull();
            result.Value.Email.Should().Be(command.Email);
        }
    }
}
