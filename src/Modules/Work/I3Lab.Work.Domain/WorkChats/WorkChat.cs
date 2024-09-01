using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.Works;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Domain.WorkChats
{
    public class WorkChat : Entity, IAggregateRoot
    {
        public WorkId WorkId { get; private set; }

        public WorkChatId Id { get; private set; }
        public List<ChatMessage> Messages { get; private set; }
        public List<Member> ChatMembers { get; private set; }

        private WorkChat() { } // For EF Core

        private WorkChat(WorkId workId, List<Member> members)
        {
            WorkId = workId;
            Messages = new List<ChatMessage>();
            ChatMembers = members;
        }

        internal static WorkChat CreateBaseOnWork(
            WorkId workId, 
            List<Member> workMembers)
        {
            return new WorkChat(
                workId, 
                workMembers);
        }

        public void AddMessage(MemberId senderId, string messageText)
        {
            if (ChatMembers.All(p => p.Id != senderId))
                throw new InvalidOperationException("Sender is not a participant in the chat.");

            var newMessage = ChatMessage.CreateNew(senderId, messageText);
            Messages.Add(newMessage);
        }

        public void AddChatMember(Member member)
        {
            if (ChatMembers.Any(p => p.Id == member.Id))
                throw new InvalidOperationException("Member is already a participant in the chat.");

           // var newParticipant = new ChatMember(memberId);
            ChatMembers.Add(member);
        }

        public void RemoveChatMember(MemberId memberId)
        {
            var participant = ChatMembers.FirstOrDefault(p => p.Id == memberId);
            if (participant == null)
                throw new InvalidOperationException("Member is not a participant in the chat.");

            ChatMembers.Remove(participant);
        }
    }
}
