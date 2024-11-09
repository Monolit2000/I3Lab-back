using FluentAssertions;
using I3lab.Works.IntegrationTests.Abstraction;
using I3Lab.Treatments.Application.TreatmentStageChats.CreatetreatmentStageChat;
using I3Lab.Treatments.Domain.TreatmentStages;
using Microsoft.EntityFrameworkCore;

namespace I3lab.Works.IntegrationTests.TreatmentStageChats
{
    public class CreateTreatmentStageChatTests : BaseIntegrationTest
    {
        public CreateTreatmentStageChatTests(IntegrationTestWebAppFactory factory) 
            : base(factory)
        {
        }

        [Fact]
        public async Task Handle_Should_CreateTreatmentStageChat_WhenTreatmentStageExists()
        {
            // Arrange
            var creator = await CreateMemberAsync();
            var patient = await CreateMemberAsync();
            var treatment = await CreateTreatmentDbAsync(creator);
            var stage = await CreateTreatmentStageAsync();

            var command = new CreateTreatmentStageChatCommand(stage.Id.Value, treatment.Id.Value);

            // Act
            await Sender.Send(command);

            var chat = await DbContext.TreatmentStageChats
                .FirstOrDefaultAsync(c => c.TreatmentStageId == stage.Id);

            chat.Should().NotBeNull();
            chat.ChatMembers.Should().ContainSingle(m => m.MemberId == creator.Id);
        }

        [Fact]
        public async Task Handle_Should_ReturnError_WhenTreatmentStageNotFound()
        {
            // Arrange
            var treatment = await CreateTreatmentDbAsync();
            var invalidStageId = Guid.NewGuid();

            var command = new CreateTreatmentStageChatCommand(invalidStageId, treatment.Id.Value);
           

            // Act
            await Sender.Send(command);

            // Assert
            var chat = await DbContext.TreatmentStageChats
                .FirstOrDefaultAsync(c => c.TreatmentStageId == new TreatmentStageId(invalidStageId));
            chat.Should().BeNull();
        }

        [Fact]
        public async Task Handle_Should_ReturnError_WhenTreatmentNotFound()
        {
            // Arrange
            var stage = await CreateTreatmentStageAsync();
            var invalidTreatmentId = Guid.NewGuid();

            var command = new CreateTreatmentStageChatCommand(stage.Id.Value, invalidTreatmentId);

            //Act
            await Sender.Send(command);

            // Assert
            var chat = await DbContext.TreatmentStageChats
                .FirstOrDefaultAsync(c => c.TreatmentStageId == stage.Id);
            chat.Should().BeNull();
        }
    }
}
