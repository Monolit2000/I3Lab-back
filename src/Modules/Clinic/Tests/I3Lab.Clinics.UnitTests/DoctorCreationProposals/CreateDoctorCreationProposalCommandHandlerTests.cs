using FluentAssertions;
using I3Lab.Clinics.Application.DoctorCreationProposals;
using I3Lab.Clinics.Application.DoctorCreationProposals.CreateDoctorCreationProposal;
using I3Lab.Clinics.Domain.DoctorCreationProposals;
using I3Lab.Clinics.Domain.Doctors;
using NSubstitute;

namespace I3Lab.Clinics.UnitTests.DoctorCreationProposals
{
    public class CreateDoctorCreationProposalCommandHandlerTests : ClinicTestsBase
    {
        private readonly IDoctorCreationProposalRepository _doctorCreationProposalRepository;
        private readonly CreateDoctorCreationProposalCommandHandler _handler;

        public CreateDoctorCreationProposalCommandHandlerTests()
        {
            _doctorCreationProposalRepository = Substitute.For<IDoctorCreationProposalRepository>();
            _handler = new CreateDoctorCreationProposalCommandHandler(_doctorCreationProposalRepository);
        }

        [Fact]
        public async Task Handle_ShouldReturnFailure_WhenProposalAlreadyExists()
        {
            // Arrange
            var command = new CreateDoctorCreationProposalCommand
            {
                Email = "test@example.com",
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "123456789",
                DoctorAvatar = "avatar.jpg"
            };

            var email = Email.Create(command.Email);

            _doctorCreationProposalRepository
                .ExistByEmailAsync(email, Arg.Any<CancellationToken>())
                .Returns(true);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == DoctorCreationProposalApplicationErrors.ProposalAlreadyExist(command.Email));
        }

        [Fact]
        public async Task Handle_ShouldCreateProposal_WhenProposalDoesNotExist()
        {
            // Arrange
            var command = new CreateDoctorCreationProposalCommand
            {
                Email = "test@example.com",
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "123456789",
                DoctorAvatar = "avatar.jpg"
            };

            var email = Email.Create(command.Email);

            _doctorCreationProposalRepository
                .ExistByEmailAsync(email, Arg.Any<CancellationToken>())
                .Returns(false);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().NotBeNull();
            await _doctorCreationProposalRepository
                .Received(1)
                .AddAsync(Arg.Any<DoctorCreationProposal>(), Arg.Any<CancellationToken>());
            await _doctorCreationProposalRepository
                .Received(1)
                .SaveChangesAsync(Arg.Any<CancellationToken>());
        }

        [Fact]
        public async Task Handle_ShouldReturnDtoWithCorrectId_WhenProposalIsCreated()
        {
            // Arrange
            var command = new CreateDoctorCreationProposalCommand
            {
                Email = "test@example.com",
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "123456789",
                DoctorAvatar = "avatar.jpg"
            };

            var email = Email.Create(command.Email);

            _doctorCreationProposalRepository
                .ExistByEmailAsync(email, Arg.Any<CancellationToken>())
                .Returns(false);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.ProposalId.Should().NotBeEmpty();
        }
    }

}
