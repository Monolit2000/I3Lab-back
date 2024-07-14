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
        public List<ChatMember> Participants { get; private set; }

        private WorkChat() { } // For EF Core

        private WorkChat(WorkId workId)
        {
            WorkId = workId;
            Messages = new List<ChatMessage>();
            Participants = new List<ChatMember>();
        }

        public static WorkChat CreateNew(WorkId workId)
        {
            return new WorkChat(workId);
        }

        public void AddMessage(MemberId senderId, string messageText)
        {
            if (Participants.All(p => p.MemberId != senderId))
                throw new InvalidOperationException("Sender is not a participant in the chat.");

            var newMessage = ChatMessage.CreateNew(senderId, messageText);
            Messages.Add(newMessage);
        }

        public void AddParticipant(MemberId memberId)
        {
            if (Participants.Any(p => p.MemberId == memberId))
                throw new InvalidOperationException("Member is already a participant in the chat.");

            var newParticipant = new ChatMember(memberId);
            Participants.Add(newParticipant);
        }

        public void RemoveParticipant(MemberId memberId)
        {
            var participant = Participants.FirstOrDefault(p => p.MemberId == memberId);
            if (participant == null)
                throw new InvalidOperationException("Member is not a participant in the chat.");

            Participants.Remove(participant);
        }
    }
}
