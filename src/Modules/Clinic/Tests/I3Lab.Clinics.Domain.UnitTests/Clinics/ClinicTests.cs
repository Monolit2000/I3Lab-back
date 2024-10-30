using FluentAssertions;
using I3Lab.Clinics.Domain.Clinics;
using I3Lab.Clinics.Domain.Clinics.Events;
using I3Lab.Clinics.Domain.Doctors;


namespace I3Lab.Clinics.Domain.UnitTests.Clinics
{
    public class ClinicTests
    {
        private Clinic CreateClinic()
        {
            return Clinic.Create(
                ClinicName.Create("Downtown Clinic"),
                ClinicAddress.Create("123 Main St"));
        }

        [Fact]
        public void Create_ShouldInitializeClinicWithGivenProperties()
        {
            // Act
            var clinic = CreateClinic();

            // Assert
            clinic.ClinicName.Value.Should().Be("Downtown Clinic");
            clinic.Address.Value.Should().Be("123 Main St");
            clinic.Status.Should().Be(ClinicStatus.Active);
            clinic.DomainEvents.Should().BeEmpty();
        }

        [Fact]
        public void AddDoctor_ShouldAddDoctorSuccessfully_WhenDoctorDoesNotExist()
        {
            // Arrange
            var clinic = CreateClinic();
            var doctorId = new DoctorId(Guid.NewGuid());

            // Act
            var result = clinic.AddDoctor(doctorId);

            // Assert
            result.IsSuccess.Should().BeTrue();
            clinic.Doctors.Should().ContainSingle(d => d.DoctorId == doctorId);
            clinic.DomainEvents.Should().ContainSingle(e => e is ClinicDoctorAddedDomainEvent);
        }

        [Fact]
        public void AddDoctor_ShouldReturnError_WhenDoctorAlreadyExists()
        {
            // Arrange
            var clinic = CreateClinic();
            var doctorId = new DoctorId(Guid.NewGuid());
            clinic.AddDoctor(doctorId); // Add doctor first time

            // Act
            var result = clinic.AddDoctor(doctorId); // Try adding the same doctor again

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == "Doctor already exists in this clinic.");
        }

        [Fact]
        public void RemoveDoctor_ShouldRemoveDoctorSuccessfully_WhenDoctorExists()
        {
            // Arrange
            var clinic = CreateClinic();
            var doctorId = new DoctorId(Guid.NewGuid());
            clinic.AddDoctor(doctorId); // Add doctor

            // Act
            clinic.RemoveDoctor(doctorId);

            // Assert
            clinic.Doctors.Should().BeEmpty();
            clinic.DomainEvents.Should().ContainSingle(e => e is ClinicDoctorRemovedDomainEvent);
        }

        [Fact]
        public void RemoveDoctor_ShouldThrowException_WhenDoctorDoesNotExist()
        {
            // Arrange
            var clinic = CreateClinic();
            var doctorId = new DoctorId(Guid.NewGuid());

            // Act
            Action act = () => clinic.RemoveDoctor(doctorId);

            // Assert
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Doctor does not exist in this clinic.");
        }

        [Fact]
        public void UpdateInfo_ShouldUpdateClinicNameAndAddress()
        {
            // Arrange
            var clinic = CreateClinic();
            var newName = ClinicName.Create("Uptown Clinic");
            var newAddress = ClinicAddress.Create("456 Broadway");

            // Act
            clinic.UpdateInfo(newName, newAddress);

            // Assert
            clinic.ClinicName.Value.Should().Be("Uptown Clinic");
            clinic.Address.Value.Should().Be("456 Broadway");
        }

        [Fact]
        public void UpdateAddress_ShouldUpdateClinicAddress()
        {
            // Arrange
            var clinic = CreateClinic();
            var newAddress = ClinicAddress.Create("789 Fifth Ave");

            // Act
            clinic.UpdateAddress(newAddress);

            // Assert
            clinic.Address.Value.Should().Be("789 Fifth Ave");
        }

        [Fact]
        public void UpdateName_ShouldUpdateClinicName()
        {
            // Arrange
            var clinic = CreateClinic();
            var newName = ClinicName.Create("Central Clinic");

            // Act
            clinic.UpdateName(newName);

            // Assert
            clinic.ClinicName.Value.Should().Be("Central Clinic");
        }
    }
}
