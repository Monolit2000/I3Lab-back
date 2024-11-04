using FluentAssertions;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Domain.TreatmentStageChats;
using I3Lab.Treatments.Domain.TreatmentStageChats.Events;
using I3Lab.Treatments.Domain.TreatmentStages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Domain.UnitTests.TreatmentStageChats
{
    public class TreatmentStageChatTests
    {
        [Fact]
        public void CreateBaseOnTreatmentStage_Should_CreateNewChat_WithMembers()
        {
            // Arrange
            var treatmentId = new TreatmentId(Guid.NewGuid());
            var treatmentStageId = new TreatmentStageId(Guid.NewGuid());
            var members = new List<Member>
            {
                Member.Create(new MemberId(Guid.NewGuid()), "member1@example.com"),
                Member.Create(new MemberId(Guid.NewGuid()), "member2@example.com")
            };

            // Act
            var chat = TreatmentStageChat.CreateBaseOnTreatmentStage(treatmentId, treatmentStageId, members);

            // Assert
            chat.TreatmentId.Should().Be(treatmentId);
            chat.TreatmentStageId.Should().Be(treatmentStageId);
            chat.ChatMembers.Should().HaveCount(2);
            chat.ChatMembers.Select(cm => cm.MemberId).Should().BeEquivalentTo(members.Select(m => m.Id));
        }

        [Fact]
        public void AddMessage_Should_AddMessage_WhenSenderIsChatMember()
        {
            // Arrange
            var chat = CreateSampleChat();
            var sender = chat.ChatMembers.First().MemberId;
            var messageText = "Hello, this is a message.";

            // Act
            var result = chat.AddMessage(sender, messageText);

            // Assert
            result.IsSuccess.Should().BeTrue();
            chat.Messages.Should().ContainSingle(m => m.MessageText == messageText && m.SenderId == sender);
        }

        [Fact]
        public void AddMessage_Should_Fail_WhenSenderIsNotChatMember()
        {
            // Arrange
            var chat = CreateSampleChat();
            var sender = new MemberId(Guid.NewGuid()); // not a chat member
            var messageText = "This should fail";

            // Act
            var result = chat.AddMessage(sender, messageText);

            // Assert
            result.IsFailed.Should().BeTrue();
            chat.Messages.Should().BeEmpty();
        }

        [Fact]
        public void AddReplyToMessage_Should_AddReplyMessage_WhenSenderAndRepliedMessageAreValid()
        {
            // Arrange
            var chat = CreateSampleChat();
            var sender = chat.ChatMembers.First().MemberId;
            var originalMessage = Message.CreateNew(sender, "Original message");
            chat.Messages.Add(originalMessage);

            // Act
            var result = chat.AddReplyToMessage(sender, originalMessage.Id, "This is a reply");

            // Assert
            result.IsSuccess.Should().BeTrue();
            chat.Messages.Should().ContainSingle(m => m.RepliedToMessageId == originalMessage.Id);
        }

        [Fact]
        public void RemoveMessage_Should_RemoveMessage_WhenMessageExists()
        {
            // Arrange
            var chat = CreateSampleChat();
            var sender = chat.ChatMembers.First().MemberId;
            var message = Message.CreateNew(sender, "Message to remove");
            chat.Messages.Add(message);

            // Act
            var result = chat.RemoveMessage(message.Id);

            // Assert
            result.IsSuccess.Should().BeTrue();
            chat.Messages.Should().NotContain(m => m.Id == message.Id);
        }

        [Fact]
        public void EditMessage_Should_EditMessageText_WhenMessageExists()
        {
            // Arrange
            var chat = CreateSampleChat();
            var sender = chat.ChatMembers.First().MemberId;
            var message = Message.CreateNew(sender, "Original Message");
            chat.Messages.Add(message);
            var newText = "Edited Message";

            // Act
            var result = chat.EditMessage(message.Id, newText);

            // Assert
            result.IsSuccess.Should().BeTrue();
            chat.Messages.First(m => m.Id == message.Id).MessageText.Should().Be(newText);
        }

        [Fact]
        public void AddChatMember_Should_AddMember_WhenMemberIsNotAlreadyInChat()
        {
            // Arrange
            var chat = CreateSampleChat();
            var newMember = Member.Create(new MemberId(Guid.NewGuid()), "newMember@example.com");

            // Act
            var result = chat.AddChatMember(newMember);

            // Assert
            result.IsSuccess.Should().BeTrue();
            chat.ChatMembers.Should().ContainSingle(cm => cm.MemberId == newMember.Id);
        }

        [Fact]
        public void RemoveChatMember_Should_RemoveMember_WhenMemberExistsInChat()
        {
            // Arrange
            var chat = CreateSampleChat();
            var memberToRemove = chat.ChatMembers.First();

            // Act
            var result = chat.RemoveChatMember(memberToRemove.MemberId);

            // Assert
            result.IsSuccess.Should().BeTrue();
            chat.ChatMembers.Should().NotContain(cm => cm.MemberId == memberToRemove.MemberId);
            chat.DomainEvents.Should().ContainSingle(e => e is ChatMemberRemovedDomainEvent);
        }

        private TreatmentStageChat CreateSampleChat()
        {
            var treatmentId = new TreatmentId(Guid.NewGuid());
            var treatmentStageId = new TreatmentStageId(Guid.NewGuid());
            var members = new List<Member>
            {
                Member.Create(new MemberId(Guid.NewGuid()), "member1@example.com"),
                Member.Create(new MemberId(Guid.NewGuid()), "member2@example.com")
            };
            return TreatmentStageChat.CreateBaseOnTreatmentStage(treatmentId, treatmentStageId, members);
        }
    }
}
