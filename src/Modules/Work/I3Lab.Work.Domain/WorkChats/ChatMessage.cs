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
        public bool IsEdited { get; private set; }
        public DateTime? EditDate { get; private set; }

        public ChatMessageId? RepliedToMessageId { get; private set; }

        private ChatMessage() { } // For EF Core

        private ChatMessage(
            MemberId senderId,
            string messageText,
            BlobFile fileResponceId = null,
            ChatMessageId? repliedToMessageId = null)
        {
            Id = new ChatMessageId(Guid.NewGuid());
            SenderId = senderId;
            MessageText = messageText;
            SentDate = DateTime.UtcNow;
            IsEdited = false;
            RepliedToMessageId = repliedToMessageId;

            if (fileResponceId != null)
            {
                FileResponceId = fileResponceId;
                AddDomainEvent(new ResponceToFileChatMessageCreatedDomainEvent());
            }
            else if (repliedToMessageId != null)
            {
                AddDomainEvent(new ReplyToChatMessageCreatedDomainEvent(repliedToMessageId.Value));
            }
            else
            {
                AddDomainEvent(new ChatMessageCreatedDomainEvent());
            }
        }

        public static ChatMessage CreateNew(
            MemberId senderId,
            string messageText,
            ChatMessageId? repliedToMessageId = null)
        {
            return new ChatMessage(
                senderId,
                messageText,
                repliedToMessageId: repliedToMessageId);
        }

        public static ChatMessage CreateNewResponceToFileMessage(
            MemberId senderId,
            string messageText,
            BlobFile blobFileId,
            ChatMessageId? repliedToMessageId = null)
        {
            return new ChatMessage(
                senderId,
                messageText,
                blobFileId,
                repliedToMessageId);
        }

        public Result Edit(string NewMessageText)
        {
            MessageText = NewMessageText;
            IsEdited = true;
            AddDomainEvent(new ChatMessageEditedDomainEvent());

            return Result.Ok();
        }

        public bool IsResponceToFileChatMessage()
        {
            return FileResponceId != null;
        }

        public bool IsEditedChatMessage()
        {
            return EditDate != null;
        }
    }
}
