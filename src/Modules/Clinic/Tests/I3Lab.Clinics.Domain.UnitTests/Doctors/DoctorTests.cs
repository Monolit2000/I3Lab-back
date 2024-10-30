using FluentAssertions;
using I3Lab.Clinics.Domain.Clinics;
using I3Lab.Clinics.Domain.Doctors;
using I3Lab.Clinics.Domain.Doctors.Events;

namespace I3Lab.Clinics.Domain.UnitTests.Doctors
{
    public class DoctorTests
    {
        private Doctor CreateDoctor()
        {
            return Doctor.CreateBaseOnProposal(
                DoctorName.Create("John", "Doe"),
                Email.Create("john.doe@example.com"),
                PhoneNumber.Create("123-456-7890"),
                DoctorAvatar.Create("http://example.com/avatar.jpg"));
        }

        private Clinic CreateClinic()
        {
            return Clinic.Create(
                ClinicName.Create("TestClinicName"),
                ClinicAddress.Create("TestClinicAddress"));
        }


        [Fact]
        public void CreateBaseOnProposal_ShouldInitializeDoctorWithGivenProperties()
        {
            // Act
            var doctor = CreateDoctor();

            // Assert
            doctor.Name.FirstName.Should().Be("John");
            doctor.Name.LastName.Should().Be("Doe");
            doctor.Email.Value.Should().Be("john.doe@example.com");
            doctor.PhoneNumber.Value.Should().Be("123-456-7890");
            doctor.DoctorAvatar.Url.Should().Be("http://example.com/avatar.jpg");
            doctor.DomainEvents.Should().ContainSingle(e => e is DoctorCreatedDomainEvent);
        }

        [Fact]
        public void AddClinic_ShouldAddClinicSuccessfully_WhenClinicIsValid()
        {
            // Arrange
            var doctor = CreateDoctor();
            var clinic = CreateClinic();
            // Act
            var result = doctor.AddClinic(clinic);

            // Assert
            result.IsSuccess.Should().BeTrue();
            doctor.Clinics.Should().ContainSingle(c => c.ClinicId == clinic.Id);
            doctor.DomainEvents.Should().ContainSingle(e => e is ClinicAddedToDoctorDomainEvent);
        }

        [Fact]
        public void AddClinic_ShouldReturnError_WhenClinicIsNull()
        {
            // Arrange
            var doctor = CreateDoctor();

            // Act
            var result = doctor.AddClinic(null);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == "Clinic cannot be null.");
        }

        [Fact]
        public void AddClinic_ShouldReturnError_WhenClinicAlreadyAssociatedWithDoctor()
        {
            // Arrange
            var doctor = CreateDoctor();
            var clinic = CreateClinic();
            doctor.AddClinic(clinic); // Add clinic first time

            // Act
            var result = doctor.AddClinic(clinic); // Try adding the same clinic again

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == "Clinic is already associated with this doctor.");
        }

        [Fact]
        public void UpdateInfo_ShouldUpdateDoctorDetails()
        {
            // Arrange
            var doctor = CreateDoctor();
            var newName = DoctorName.Create("Jane", "Smith");
            var newEmail = Email.Create("jane.smith@example.com");
            var newPhone = PhoneNumber.Create("098-765-4321");
            var newAvatar = DoctorAvatar.Create("http://example.com/new-avatar.jpg");

            // Act
            doctor.UpdateInfo(newName, newEmail, newPhone, newAvatar);

            // Assert
            doctor.Name.FirstName.Should().Be("Jane");
            doctor.Name.LastName.Should().Be("Smith");
            doctor.Email.Value.Should().Be("jane.smith@example.com");
            doctor.PhoneNumber.Value.Should().Be("098-765-4321");
            doctor.DoctorAvatar.Url.Should().Be("http://example.com/new-avatar.jpg");
        }
    }
}
