using NSubstitute;
using FluentAssertions;
using I3Lab.Clinics.Domain.Clinics;
using I3Lab.Clinics.Application.Clnics;
using I3Lab.Clinics.Domain.Clinics.Errors;
using I3Lab.Clinics.Application.Clnics.AddClinicDoctor;

namespace I3Lab.Clinics.UnitTests.Clinics
{
    public class AddClinicDoctorCommandHandlerTests : ClinicTestsBase
    {
        private readonly IClinicRepository _clinicRepository;
        private readonly AddClinicDoctorCommandHandler _handler;

        public AddClinicDoctorCommandHandlerTests()
        {
            _clinicRepository = Substitute.For<IClinicRepository>();
            _handler = new AddClinicDoctorCommandHandler(_clinicRepository);
        }

        [Fact]
        public async Task Handle_ShouldAddDoctorToClinic_WhenClinicExistsAndDoctorIsNotAdded()
        {
            // Arrange

            var clinic = CreateClinicTestData().Clinic;
            var command = new AddClinicDoctorCommand(Guid.NewGuid(), Guid.NewGuid());

            _clinicRepository.GetByIdAsync(Arg.Any<ClinicId>()).Returns(clinic);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeTrue();
            await _clinicRepository.Received(1).SaveChangesAsync();
        }

        [Fact]
        public async Task Handle_ShouldReturnFailure_WhenClinicDoesNotExist()
        {
            // Arrange
            var command = new AddClinicDoctorCommand(Guid.NewGuid(), Guid.NewGuid());
            _clinicRepository.GetByIdAsync(Arg.Any<ClinicId>()).Returns((Clinic)null);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == ClinicApplicationError.ClinicNotFound);
            await _clinicRepository.DidNotReceive().SaveChangesAsync();
        }

        [Fact]
        public async Task Handle_ShouldReturnFailure_WhenAddingDoctorFails()
        {
            // Arrange
            var testData = CreateClinicTestData();
            var clinic = testData.Clinic;
            var doctor = testData.Doctor;

            var command = new AddClinicDoctorCommand(Guid.NewGuid(), doctor.Id.Value);

            clinic.AddDoctor(doctor.Id);


            _clinicRepository.GetByIdAsync(Arg.Any<ClinicId>()).Returns(clinic);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == ClinicDomainErrors.DoctorAlreadyAdded);
            await _clinicRepository.DidNotReceive().SaveChangesAsync();
        }
    }
}
