using FluentAssertions;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Domain.TreatmentFiles;
using I3Lab.Treatments.Domain.TreatmentStages;
using I3Lab.Treatments.Domain.TreatmentStages.Events;


namespace I3Lab.Treatments.Domain.UnitTests.TreatmentStages
{
    public class TreatmentStageTests
    {
        [Fact]
        public async Task CreateBasedOnTreatmentAsync_Should_CreateNewTreatmentStage_WhenMemberRoleIsValid()
        {
            // Arrange
            var creator = Member.Create(new MemberId(Guid.NewGuid()), "testEmail@gmail.com");
            var treatmentId = new TreatmentId(Guid.NewGuid());
            var workTitle = TreatmentStageTitel.Create("Initial Treatment");

            // Act
            var result = await TreatmentStage.CreateBasedOnTreatmentAsync(creator, treatmentId, workTitle);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Creator.Should().Be(creator);
            result.Value.TreatmentId.Should().Be(treatmentId);
            result.Value.Titel.Should().Be(workTitle);
            result.Value.TreatmentStageStatus.Should().Be(TreatmentStageStatus.Pending);
            result.Value.DomainEvents.Should().ContainSingle(e => e is WorkCreatedDomainEvent);
        }

        [Fact]
        public void ChangeStatus_Should_UpdateStatus_WhenNewStatusIsDifferent()
        {
            // Arrange
            var treatmentStage = CreateSampleTreatmentStage();
            var newStatus = TreatmentStageStatus.Active;

            // Act
            var result = treatmentStage.ChangeStatus(newStatus);

            // Assert
            result.IsSuccess.Should().BeTrue();
            treatmentStage.TreatmentStageStatus.Should().Be(newStatus);
            treatmentStage.DomainEvents.Should().ContainSingle(e => e is WorkStatusChangedDomainEvent);
        }

        [Fact]
        public void Close_Should_SetStatusToClosed_WhenStatusIsNotClosed()
        {
            // Arrange
            var treatmentStage = CreateSampleTreatmentStage();

            // Act
            var result = treatmentStage.Close();

            // Assert
            result.IsSuccess.Should().BeTrue();
            treatmentStage.TreatmentStageStatus.Should().Be(TreatmentStageStatus.Closed);
            treatmentStage.DomainEvents.Should().ContainSingle(e => e is TreatmentStageClosedDomainEvent);
        }

        [Fact]
        public void AddWorkFile_Should_AddFileToTreatmentStageFiles()
        {
            // Arrange
            var treatmentStage = CreateSampleTreatmentStage();
            var fileId = new TreatmentFile(); 

            // Act
            treatmentStage.AddWorkFile(treatmentStage.Id, fileId);

            // Assert
            treatmentStage.TreatmentStageFiles.Should().ContainSingle(f => f.File == fileId);
        }
        private TreatmentStage CreateSampleTreatmentStage()
        {
            var creator = Member.Create(new MemberId(Guid.NewGuid()), "testEmail@gmail.com");
            var treatmentId = new TreatmentId(Guid.NewGuid());
            var workTitle = TreatmentStageTitel.Create("Initial Treatment");
            return TreatmentStage.CreateBasedOnTreatment(creator, treatmentId, workTitle).Value;
        }

        //[Fact]
        //public void SetWorkAvatarImage_Should_SetAvatarImage_AndAddDomainEvent()
        //{
        //    // Arrange
        //    var treatmentStage = CreateSampleTreatmentStage();
        //    var workFile = new TreatmentStageFile(); // Предполагаем, что объект создан корректно

        //    // Act
        //    treatmentStage.SetWorkAvatarImage(workFile);

        //    // Assert
        //    treatmentStage.TreatmentStageAvatarImage.Should().Be(workFile);
        //    treatmentStage.DomainEvents.Should().ContainSingle(e => e is WorkAvatarImageSetDomainEvent);
        //}

    }
}
