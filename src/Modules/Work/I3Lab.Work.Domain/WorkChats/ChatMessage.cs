using FluentResults;
using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.BlobFiles;
using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.WorkChats.Events;


namespace I3Lab.Works.Domain.WorkChats
{
    public class ChatMessage : Entity
    {
        public WorkChatId WorkChatId { get; private set; }
        public MemberId SenderId { get; private set; }

        public ChatMessageId Id { get; private set; }
        public string MessageText { get; private set; }
        public DateTime SentDate { get; private set; }
        public BlobFile FileResponceId { get; private set; }

        public DateTime? EditDate { get; private set; }

        private ChatMessage() { } // For EF Core

        private ChatMessage(MemberId senderId, string messageText, BlobFile fileResponceId = null)
        {
            SenderId = senderId;
            MessageText = messageText;
            SentDate = DateTime.UtcNow;

            if (fileResponceId != null)
            {
                FileResponceId = fileResponceId;
                AddDomainEvent(new ResponceToFileChatMessageCreatedDomainEvent());
            }
            else
                AddDomainEvent(new ChatMessageCreatedDomainEvent());
        }

        public static ChatMessage CreateNew(
            MemberId senderId, 
            string messageText)
        {
            return new ChatMessage(
                senderId, 
                messageText);
        }

        public static ChatMessage CreateNewResponceToFileMessage(
            MemberId senderId, 
            string messageText,
            BlobFile blobFileId)
        {
            return new ChatMessage(
                senderId, 
                messageText, 
                blobFileId);
        }

        public Result EditChatMessage(string NewMessageText)
        {
            MessageText = NewMessageText;
            AddDomainEvent(new ChatMessageEditedDomainEvent());

            return Result.Ok();
        }

        public bool IsResponceToFileChatMessage()
        {
            if (FileResponceId == null)
                return false;

            return true;
        }

        public bool IsEditedChatMessage()
        {
            if (EditDate == null)
                return false;

            return true;
        }

    }
}
