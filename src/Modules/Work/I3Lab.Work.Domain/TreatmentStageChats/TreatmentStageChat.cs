using FluentResults;
using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.TreatmentStages;
using I3Lab.Treatments.Domain.TreatmentStageChats.Events;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Domain.TreatmentFiles;
using I3Lab.Treatments.Domain.TreatmentStageChats.Rules;

namespace I3Lab.Treatments.Domain.TreatmentStageChats
{
    public class TreatmentStageChat : Entity, IAggregateRoot
    {
        public TreatmentId TreatmentId { get; private set; }
        public TreatmentStageId TreatmentStageId { get; private set; }

        public List<Message> Messages { get; private set; } = [];
        public List<ChatMember> ChatMembers { get; private set; } = [];

        public TreatmentStageChatId Id { get; private set; }

        private TreatmentStageChat() { } // For EF Core

        private TreatmentStageChat(
            TreatmentId treatmentId,
            TreatmentStageId treatmentStageId, 
            List<Member> members)
        {
            Id = new TreatmentStageChatId(Guid.NewGuid());
            TreatmentId = treatmentId;
            TreatmentStageId = treatmentStageId;

            ChatMembers = members.Select(x => ChatMember.CreateNew(this.Id, x.Id)).ToList();
        }

        public static TreatmentStageChat Create(
            TreatmentId treatmentId,
            TreatmentStageId workId,
            List<Member> workMembers) 
            => new TreatmentStageChat(
                treatmentId,
                workId,
                workMembers);

        public static TreatmentStageChat CreateBaseOnTreatmentStage(
            TreatmentId treatmentId,
            TreatmentStageId workId, 
            List<Member> workMembers)
        {
            return new TreatmentStageChat(
                treatmentId,
                workId, 
                workMembers);
        }


        public Result AddMessage(MemberId senderId, string messageText)
        {
            var result = CheckRules(
                new SenderMustBeChatMemberRule(ChatMembers, senderId));
                //new RepliedMessageMustExistRule(Messages, repliedToMessageId));
            if (result.IsFailed)
                return result;

            var newMessage = Message.CreateNew(senderId, messageText);
            Messages.Add(newMessage);

            return Result.Ok();
        }

        public Result AddReplyToMessage(MemberId senderId, MessageId repliedToMessageId, string messageText)
        {
            var result = CheckRules(
                new SenderMustBeChatMemberRule(ChatMembers, senderId),
                new RepliedMessageMustExistRule(Messages, repliedToMessageId));
            if (result.IsFailed)
                return result;


            var replyMessage = Message.CreateNew(senderId, messageText, repliedToMessageId);
            Messages.Add(replyMessage);

            return Result.Ok();
        }

        public Result AddResponseToFileMessage(MemberId senderId, TreatmentFile fileResponceId, string messageText = "", MessageId repliedToMessageId = null)
        {
            var result = CheckRules(
                new SenderMustBeChatMemberRule(ChatMembers, senderId),
                new RepliedMessageMustExistRule(Messages, repliedToMessageId));
            if (result.IsFailed)
                return result;

            var newMessage = Message.CreateResponceToFileMessage(senderId, messageText, fileResponceId, repliedToMessageId);
            Messages.Add(newMessage);

            return Result.Ok();
        }


        public Result RemoveMessage(MessageId chatMessageId)
        {
            var message = Messages.FirstOrDefault(p => p.Id == chatMessageId);

            if (message == null)
                return Result.Fail("Message not found");

            Messages.Remove(message);
            return Result.Ok();
        }

        public Result EditMessage(MessageId chatMessageId, string newMessage)
        {
            var message = Messages.FirstOrDefault(p => p.Id == chatMessageId);
            if (message == null)
                return Result.Fail("Message not found");

            //var result = CheckRules(new MemberMustBeInChatRule(ChatMembers, member.Id));
            //if (result.IsFailed)
            //    return result;

            message.Edit(newMessage);

            return Result.Ok();
        }


        public Result EditMessage(MessageId chatMessageId, MemberId editorId, string newMessage)
        {
            var message = Messages.FirstOrDefault(p => p.Id == chatMessageId);
            if (message == null)
                return Result.Fail("Message not found");

            var result = CheckRules(
                new MemberMustBeInChatRule(ChatMembers, editorId),
                new MemberMustBeMessageOwnerRule(message, editorId));
            if (result.IsFailed)
                return result;

            message.Edit(newMessage);

            return Result.Ok();
        }


        public Result AddChatMember(Member member)
        {
            var result = CheckRules(new MemberMustNotBeAlreadyInChatRule(ChatMembers, member.Id));
            if (result.IsFailed)
                return result;

            var chatMember = ChatMember.CreateNew(Id, member.Id);
            ChatMembers.Add(chatMember);

            return Result.Ok();
        }

        public Result RemoveChatMember(MemberId memberId)
        {
            var member = ChatMembers.FirstOrDefault(p => p.MemberId == memberId);
            if (member == null)
                return Result.Fail("Member not found in the chat.");

            ChatMembers.Remove(member);
            AddDomainEvent(new ChatMemberRemovedDomainEvent(this.Id, member.MemberId));

            return Result.Ok();
        }
    }
}


