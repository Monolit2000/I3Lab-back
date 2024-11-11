using FluentAssertions;
using I3lab.Works.IntegrationTests.Abstraction;
using I3Lab.Treatments.Application.TreatmentStageChats.AddChatMemberToAllTreatmentStageChatsByTreatmentId;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments;
using Microsoft.EntityFrameworkCore;


namespace I3lab.Works.IntegrationTests.TreatmentStageChats
{
    public class AddChatMemberToAllTreatmentStageChatsTests : BaseIntegrationTest
    {
        public AddChatMemberToAllTreatmentStageChatsTests(IntegrationTestWebAppFactory factory) : base(factory)
        {
        }

        [Fact]
        public async Task Handle_Should_AddChatMemberToAllTreatmentStageChats()
        {
            // Arrange
            var creator = await CreateMemberAsync();
            var patient = await CreateMemberAsync();
            var memberToAdd = await CreateMemberAsync();
            var treatment = await CreateTreatmentDbAsync(creator: creator, patient: patient);

            var stage1 = await CreateTreatmentStageAsync(treatment.Id);
            var stage2 = await CreateTreatmentStageAsync(treatment.Id);

            var chat1 = stage1.CreateTreatmentStageChat([creator, patient]);
            var chat2 = stage2.CreateTreatmentStageChat([creator, patient]);

            await DbContext.TreatmentStageChats.AddRangeAsync(chat1, chat2);

            // Arrange
            await DbContext.SaveChangesAsync();

            var command = new AddChatMemberToAllTreatmentStageChatsByTreatmentIdCommand(memberToAdd.Id, treatment.Id);

            // Act
            await Sender.Send(command);

            //Assert
            var updatedChat1 = await DbContext.TreatmentStageChats
                .Include(c => c.ChatMembers)
                .FirstOrDefaultAsync(c => c.TreatmentId == treatment.Id);

            var updatedChat2 = await DbContext.TreatmentStageChats
                .Include(c => c.ChatMembers)
                .FirstOrDefaultAsync(c => c.TreatmentId == treatment.Id);

            updatedChat1.ChatMembers.Should().ContainSingle(m => m.MemberId == memberToAdd.Id);
            updatedChat2.ChatMembers.Should().ContainSingle(m => m.MemberId == memberToAdd.Id);
        }

        [Fact]
        public async Task Handle_Should_DoNothing_WhenTreatmentStagesNotFound()
        {
            // Arrange
            var memberToAdd = await CreateMemberAsync();
            var invalidTreatmentId = new TreatmentId(Guid.NewGuid());

            var command = new AddChatMemberToAllTreatmentStageChatsByTreatmentIdCommand(memberToAdd.Id, invalidTreatmentId);
            // Act
            await Sender.Send(command);

            // Assert - no chats should contain the new member
            var chats = await DbContext.TreatmentStageChats
                .Include(c => c.ChatMembers)
                .ToListAsync();

            chats.Should().BeEmpty(); 
        }

        [Fact]
        public async Task Handle_Should_DoNothing_WhenMemberNotFound()
        {
            // Arrange
            var creator = await CreateMemberAsync();
            var patient = await CreateMemberAsync();
            var treatment = await CreateTreatmentDbAsync(creator);

            // Создаем этап с чатом
            var stage = await CreateTreatmentStageAsync();
            var chat = stage.CreateTreatmentStageChat([creator, patient]);

            await DbContext.TreatmentStageChats.AddAsync(chat);
            await DbContext.SaveChangesAsync();

            var invalidMemberId = new MemberId(Guid.NewGuid());

            var command = new AddChatMemberToAllTreatmentStageChatsByTreatmentIdCommand(invalidMemberId, treatment.Id);

            await Sender.Send(command);

            // Assert - chat should not contain the invalid member
            var updatedChat = await DbContext.TreatmentStageChats
                .Include(c => c.ChatMembers)
                .FirstOrDefaultAsync(c => c.Id == chat.Id);

            updatedChat.ChatMembers.Should().OnlyContain(m => m.MemberId != invalidMemberId);
        }
    }
}
