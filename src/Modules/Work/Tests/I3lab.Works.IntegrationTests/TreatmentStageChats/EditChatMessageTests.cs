using Bogus;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using I3lab.Works.IntegrationTests.Abstraction;
using I3Lab.Treatments.Application.TreatmentStageChats.EditChatMessage;

namespace I3lab.Works.IntegrationTests.TreatmentStageChats
{
    public class EditChatMessageTests : BaseIntegrationTest
    {
        public EditChatMessageTests(IntegrationTestWebAppFactory factory) : base(factory) { }

        [Fact]
        public async Task Handle_Should_EditMessage_WhenChatAndMessageExist()
        {
            // Arrange
            var creator = await CreateMemberAsync();
            var patient = await CreateMemberAsync();
            var treatmentStage = await CreateTreatmentStageAsync();
            var chat = treatmentStage.CreateTreatmentStageChat([creator, patient ]);

            var originalMessageText = Faker.Lorem.Sentence();
            chat.AddMessage(creator.Id, originalMessageText);
            await DbContext.TreatmentStageChats.AddAsync(chat);
            await DbContext.SaveChangesAsync();

            var messageId = chat.Messages.First().Id.Value;
            var editedMessageText = Faker.Lorem.Sentence();
            var command = new EditChatMessageCommand(
                treatmentStage.Id.Value,
                creator.Id.Value,
                messageId,
                editedMessageText
            );

            // Act
            var result = await Sender.Send(command);

            // Assert
            result.IsSuccess.Should().BeTrue();
            var updatedChat = await DbContext.TreatmentStageChats
                .Include(c => c.Messages)
                .FirstOrDefaultAsync(c => c.Id == chat.Id);

            updatedChat.Messages.Should().ContainSingle(m => m.Id.Value == messageId && m.MessageText == editedMessageText);
        }

        [Fact]
        public async Task Handle_Should_ReturnError_WhenChatNotFound()
        {
            // Arrange
            var nonExistentTreatmentStageId = Guid.NewGuid();
            var editor = await CreateMemberAsync();
            var messageId = Guid.NewGuid();
            var editedMessageText = Faker.Lorem.Sentence();

            var command = new EditChatMessageCommand(
                nonExistentTreatmentStageId,
                editor.Id.Value,
                messageId,
                editedMessageText
            );

            // Act
            var result = await Sender.Send(command);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == "Chat not found");
        }

        [Fact]
        public async Task Handle_Should_ReturnError_WhenMessageNotFound()
        {
            // Arrange
            var creator = await CreateMemberAsync();
            var treatmentStage = await CreateTreatmentStageAsync();
            var chat = treatmentStage.CreateTreatmentStageChat([ creator ]);

            await DbContext.TreatmentStageChats.AddAsync(chat);
            await DbContext.SaveChangesAsync();

            var nonExistentMessageId = Guid.NewGuid();
            var editedMessageText = Faker.Lorem.Sentence();
            var command = new EditChatMessageCommand(
                treatmentStage.Id.Value,
                creator.Id.Value,
                nonExistentMessageId,
                editedMessageText
            );

            // Act
            var result = await Sender.Send(command);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == "Message not found");
        }

        //[Fact]
        //public async Task Handle_Should_ReturnError_WhenEditorNotInChat()
        //{
        //    // Arrange
        //    var creator = await CreateMemberAsync();
        //    var unrelatedMember = await CreateMemberAsync();
        //    var treatmentStage = await CreateTreatmentStageAsync();
        //    var chat = treatmentStage.CreateTreatmentStageChat([creator ]);

        //    var originalMessageText = Faker.Lorem.Sentence();
        //    chat.AddMessage(creator.Id, originalMessageText);
        //    await DbContext.TreatmentStageChats.AddAsync(chat);
        //    await DbContext.SaveChangesAsync();

        //    var messageId = chat.Messages.First().Id.Value;
        //    var editedMessageText = Faker.Lorem.Sentence();
        //    var command = new EditChatMessageCommand(
        //        treatmentStage.Id.Value,
        //        unrelatedMember.Id.Value,
        //        messageId,
        //        editedMessageText
        //    );

        //    // Act
        //    var result = await Sender.Send(command);

        //    // Assert
        //    result.IsFailed.Should().BeTrue();
        //    result.Errors.Should().ContainSingle(e => e.Message == "Editor not in chat");
        //}
    }
}
