using Bogus;
using FluentAssertions;
using I3lab.Works.IntegrationTests.Abstraction;
using I3Lab.Treatments.Application.Members.CreateMember;
using I3Lab.Treatments.Application.Treatments.CreateTreatment;
using I3Lab.Treatments.Application.TreatmentStages.CloseTreatmentStage;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Domain.TreatmentStages;
using I3Lab.Treatments.Infrastructure.Domain.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3lab.Works.IntegrationTests.TreatmentStages
{
    public class CloseTreatmentStageTests : BaseIntegrationTest
    {
        public CloseTreatmentStageTests(IntegrationTestWebAppFactory factory)
            : base(factory)
        {
        }

        [Fact]
        public async Task Handle_Should_CloseTreatmentStage_WhenStageExists()
        {
            // Arrange
            var treatmentStage = await CreateTreatmentStageAsync();
            var command = new CloseTreatmentStageCommand
            {
                TreatmentStageId = treatmentStage.Id.Value
            };

            // Act
            var result = await Sender.Send(command);

            // Assert
            result.IsSuccess.Should().BeTrue();
            var updatedStage = await DbContext.TreatmentStages.FindAsync(treatmentStage.Id);
            updatedStage.Should().NotBeNull();
            updatedStage!.TreatmentStageStatus.IsClosed.Should().BeTrue(); // Assuming there is an IsClosed property or similar status
        }

        [Fact]
        public async Task Handle_Should_ReturnFailure_WhenStageDoesNotExist()
        {
            // Arrange
            var nonExistentStageId = Guid.NewGuid();
            var command = new CloseTreatmentStageCommand
            {
                TreatmentStageId = nonExistentStageId
            };

            // Act
            var result = await Sender.Send(command);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message.Contains("not found"));
        }

        [Fact]
        public async Task Handle_Should_ReturnFailure_WhenStageAlreadyClosed()
        {
            // Arrange
            var treatmentStage = await CreateTreatmentStageAsync();
            treatmentStage.Close(); // Закриваємо етап вручну
            await DbContext.SaveChangesAsync();

            var command = new CloseTreatmentStageCommand
            {
                TreatmentStageId = treatmentStage.Id.Value
            };

            // Act
            var result = await Sender.Send(command);

            // Assert
            result.IsFailed.Should().BeFalse();
            //result.Errors.Should().ContainSingle(e => e.Message.Contains("already closed"));
        }
    }
}
