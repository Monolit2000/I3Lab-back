using FluentResults;
using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.WorkChats.Events;
using I3Lab.Works.Domain.Works;

namespace I3Lab.Works.Domain.WorkChats
{
    public class WorkChat : Entity, IAggregateRoot
    {
        public WorkId WorkId { get; private set; }
        public List<ChatMessage> Messages { get; private set; } = [];
        public List<ChatMember> ChatMembers { get; private set; } = [];


        public WorkChatId Id { get; private set; }
        private WorkChat() { } // For EF Core

        private WorkChat(
            WorkId workId, 
            List<Member> members)
        {
            Id = new WorkChatId(Guid.NewGuid());
            WorkId = workId;
            ChatMembers = members.Select(x => ChatMember.CreateNew(this.Id, x.Id)).ToList();
        }

        public static WorkChat CreaterWorkChut(
            WorkId workId,
            List<Member> workMembers)
        {
            return new WorkChat(
               workId,
               workMembers);
        }

        public static WorkChat CreateBaseOnWork(
            WorkId workId, 
            List<Member> workMembers)
        {
            return new WorkChat(
                workId, 
                workMembers);
        }

        //public void AddMessage(MemberId senderId, string messageText)
        //{
        //    if (ChatMembers.All(p => p.MemberId != senderId))
        //        throw new InvalidOperationException("Sender is not a member in the chat.");

        //    var newMessage = ChatMessage.CreateNew(senderId, messageText);
        //    Messages.Add(newMessage);
        //}



        public Result AddMessage(MemberId senderId, string messageText, ChatMessageId repliedToMessageId = null)
        {
            if (ChatMembers.All(p => p.MemberId != senderId))
                return Result.Fail("Sender is not a member in the chat.");

            if (repliedToMessageId != null)
            {
                var originalMessage = Messages.FirstOrDefault(m => m.Id == repliedToMessageId);
                if (originalMessage == null)
                    return Result.Fail("Replied message not found.");
            }

            var newMessage = ChatMessage.CreateNew(senderId, messageText, repliedToMessageId);
            Messages.Add(newMessage);

            return Result.Ok();
        }

        public Result AddReplyToMessage(MemberId senderId, ChatMessageId repliedToMessageId, string messageText)
        {
            if (ChatMembers.All(p => p.MemberId != senderId))
                return Result.Fail("Sender is not a member in the chat.");

            var originalMessage = Messages.FirstOrDefault(m => m.Id == repliedToMessageId);
            if (originalMessage == null)
                return Result.Fail("Replied message not found.");

            var replyMessage = ChatMessage.CreateNew(senderId, messageText, repliedToMessageId);
            Messages.Add(replyMessage);

            return Result.Ok();
        }

        public void RemoveMessage(ChatMessageId chatMessageId)
        {
            var message = Messages.FirstOrDefault(p => p.Id == chatMessageId);

            if (message == null)
                throw new InvalidOperationException("Messages not faund.");

            Messages.Remove(message); 
        }

        public Result EditMessage(ChatMessageId chatMessageId, string newMessage)
        {
            var message = Messages.FirstOrDefault(p => p.Id == chatMessageId);

            message.Edit(newMessage);

            return Result.Ok();
        }

        public void AddChatMember(Member member)
        {
            if (ChatMembers.Any(p => p.MemberId == member.Id))
                throw new InvalidOperationException("MemberToInvite is already a member in the chat.");

            var chatMember = ChatMember.CreateNew(Id, member.Id);

           // var newParticipant = new ChatMember(memberId);
            ChatMembers.Add(chatMember);
        }

        public void RemoveChatMember(MemberId memberId)
        {
            var member = ChatMembers.FirstOrDefault(p => p.MemberId == memberId);
            if (member == null)
                throw new InvalidOperationException("MemberToInvite is not a member in the chat.");

            ChatMembers.Remove(member);

            AddDomainEvent(new ChatMemberRemovedDamainEvent(this.Id, member.MemberId));
        }
    }
}
