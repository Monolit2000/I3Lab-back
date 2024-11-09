using Bogus;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using I3lab.Works.IntegrationTests.Abstraction;
using I3Lab.Treatments.Domain.TreatmentStageChats.Errors;
using I3Lab.Treatments.Application.TreatmentStageChats.AddMessage;
using I3Lab.Treatments.Application.TreatmentStageChats;

namespace I3lab.Works.IntegrationTests.TreatmentStageChats
{
    public class AddMessageTests : BaseIntegrationTest
    {
        public AddMessageTests(IntegrationTestWebAppFactory factory) : base(factory) { }

        [Fact]
        public async Task Handle_Should_AddMessageToTreatmentStageChat_WhenChatExists()
        {
            // Arrange
            var creator = await CreateMemberAsync();
            var patient = await CreateMemberAsync();
            var treatmentStage = await CreateTreatmentStageAsync();
            var chat = treatmentStage.CreateTreatmentStageChat([ creator, patient ]);

            await DbContext.TreatmentStageChats.AddAsync(chat);
            await DbContext.SaveChangesAsync();

            var messageText = Faker.Lorem.Sentence();
            var command = new AddMessageCommand(treatmentStage.Id.Value, creator.Id.Value, messageText);

            // Act
            var result = await Sender.Send(command);

            // Assert
            result.IsSuccess.Should().BeTrue();
            var updatedChat = await DbContext.TreatmentStageChats
                .Include(c => c.Messages)
                .FirstOrDefaultAsync(c => c.Id == chat.Id);

            updatedChat.Messages.Should().ContainSingle(m => m.MessageText == messageText && m.SenderId == creator.Id);
        }

        [Fact]
        public async Task Handle_Should_ReturnError_WhenTreatmentStageChatNotFound()
        {
            // Arrange
            var nonExistentTreatmentStageId = Guid.NewGuid();
            var member = await CreateMemberAsync();
            var messageText = Faker.Lorem.Sentence();

            var command = new AddMessageCommand(nonExistentTreatmentStageId, member.Id.Value, messageText);

            // Act
            var result = await Sender.Send(command);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == TreatmentStageChatsApplicationErrors.TreatmentStageChatNotFound);
        }

        [Fact]
        public async Task Handle_Should_ReturnError_WhenSenderNotInChat()
        {
            // Arrange
            var creator = await CreateMemberAsync();
            var unrelatedMember = await CreateMemberAsync();
            var treatmentStage = await CreateTreatmentStageAsync();
            var chat = treatmentStage.CreateTreatmentStageChat([creator ]);

            await DbContext.TreatmentStageChats.AddAsync(chat);
            await DbContext.SaveChangesAsync();

            var messageText = Faker.Lorem.Sentence();
            var command = new AddMessageCommand(treatmentStage.Id.Value, unrelatedMember.Id.Value, messageText);

            // Act
            var result = await Sender.Send(command);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == TreatmentStageChatsDomainErrors.SenderNotInChat);
        }
    }
}
