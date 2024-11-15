using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using I3lab.Works.IntegrationTests.Abstraction;
using I3Lab.Treatments.Application.Works.CreateWorks;

namespace I3lab.Works.IntegrationTests.Works
{
    public class CreateTreatmentStagesTests : BaseIntegrationTest
    {
        public CreateTreatmentStagesTests(IntegrationTestWebAppFactory factory)
            : base(factory)
        {

        }

        [Fact]
        public async Task Handle_Should_CreateTreatmentStages_WhenCommandIsValid()
        {
            // Arrange
            var creator = await CreateMemberAsync();
            var treatment = await CreateTreatmentDbAsync();
            var command = new CreateTreatmentStagesCommand(creator.Id.Value, treatment.Id.Value);


            // Act
            await Sender.Send(command);

            // Assert
            var stages = await DbContext.TreatmentStages
                .Where(x => x.TreatmentId == treatment.Id)
                .ToListAsync();

            stages.Should().NotBeEmpty();
            stages.Should().HaveCount(4);
        }

        [Fact]
        public async Task Handle_Should_LogWarning_WhenCreatorNotFound()
        {
            // Arrange
            var invalidCreatorId = Guid.NewGuid();
            var treatment = await CreateTreatmentDbAsync();

            var command = new CreateTreatmentStagesCommand(invalidCreatorId, treatment.Id.Value);

            // Act
            await Sender.Send(command);

            var stages = await DbContext.TreatmentStages
            .Where(x => x.TreatmentId == treatment.Id)
            .ToListAsync();

            // Assert
            stages.Should().NotBeEmpty();   
        }

        //[Fact]
        //public async Task Handle_Should_LogError_WhenTreatmentStageCreationFails()
        //{
        //    // Arrange
        //    var creator = await CreateMemberAsync();
        //    var invalidTreatmentId = Guid.NewGuid();

        //    var command = new CreateTreatmentStagesCommand(creator.Id.Value, invalidTreatmentId);

        //    // Act
        //    await Sender.Send(command);

        //    // Assert
        //}
    }
}
