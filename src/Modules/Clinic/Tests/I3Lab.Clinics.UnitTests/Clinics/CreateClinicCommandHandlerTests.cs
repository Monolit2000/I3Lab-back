using FluentAssertions;
using FluentResults;
using I3Lab.Clinics.Application.Clnics;
using I3Lab.Clinics.Application.Clnics.CreateClnic;
using I3Lab.Clinics.Domain.Clinics;
using NSubstitute;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace I3Lab.Clinics.UnitTests.Application.Clnics
{
    public class CreateClinicCommandHandlerTests
    {
        private readonly IClinicRepository _clinicRepository;
        private readonly CreateCilnicCommandHandler _handler;

        public CreateClinicCommandHandlerTests()
        {
            _clinicRepository = Substitute.For<IClinicRepository>();
            _handler = new CreateCilnicCommandHandler(_clinicRepository);
        }

        [Fact]
        public async Task Handle_ShouldCreateClinic_WhenClinicDoesNotExist()
        {
            // Arrange
            var command = new CreateClinicCommand("New Clinic", "123 Clinic St.");
            _clinicRepository.ExistByName(Arg.Any<ClinicName>()).Returns(false);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeTrue();
            await _clinicRepository.Received(1).AddAsync(Arg.Is<Clinic>(c => c.ClinicName.Value == "New Clinic" && c.Address.Value == "123 Clinic St."));
            await _clinicRepository.Received(1).SaveChangesAsync();
        }

        [Fact]
        public async Task Handle_ShouldReturnFailure_WhenClinicAlreadyExists()
        {
            // Arrange
            var command = new CreateClinicCommand("Existing Clinic", "456 Clinic Ave.");
            _clinicRepository.ExistByName(Arg.Any<ClinicName>()).Returns(true);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == ClinicApplicationError.ClinicAlreadyExist("Existing Clinic"));
            await _clinicRepository.DidNotReceive().AddAsync(Arg.Any<Clinic>());
            await _clinicRepository.DidNotReceive().SaveChangesAsync();
        }
    }
}
