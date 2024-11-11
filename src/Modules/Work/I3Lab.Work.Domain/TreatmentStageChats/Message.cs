using FluentResults;
using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.TreatmentFiles;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.TreatmentStageChats.Events;

namespace I3Lab.Treatments.Domain.TreatmentStageChats
{
    public class Message : Entity
    {
        public TreatmentStageChatId WorkChatId { get; private set; }
        public MemberId SenderId { get; private set; }

        public MessageId Id { get; private set; }
        public TreatmentFile FileResponceId { get; private set; }
        public string MessageText { get; private set; }
        public bool IsEdited { get; private set; }
        public DateTime SentDate { get; private set; }
        public DateTime? EditDate { get; private set; }

        public MessageId RepliedToMessageId { get; private set; }

        private Message() { } // For EF Core

        private Message(
            MemberId senderId,
            string messageText,
            TreatmentFile fileResponceId = null,
            MessageId repliedToMessageId = null)
        {
            Id = new MessageId(Guid.NewGuid());
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

        public static Message CreateNew(
            MemberId senderId,
            string messageText,
            MessageId repliedToMessageId = null)
        {
            return new Message(
                senderId,
                messageText,
                repliedToMessageId: repliedToMessageId);
        }

        public static Message CreateResponceToFileMessage(
            MemberId senderId,
            string messageText,
            TreatmentFile blobFileId,
            MessageId repliedToMessageId = null)
        {
            return new Message(
                senderId,
                messageText,
                blobFileId,
                repliedToMessageId);
        }

        public Result Edit(string EditedMessageText)
        {
            MessageText = EditedMessageText;
            IsEdited = true;
            EditDate = DateTime.UtcNow;
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
