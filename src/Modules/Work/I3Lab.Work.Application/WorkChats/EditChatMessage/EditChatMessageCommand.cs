using FluentResults;
using I3Lab.Works.Domain.Works;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.WorkChats.EditChatMessage
{
    public class EditChatMessageCommand : IRequest<Result>
    {
        public Guid WorkId { get; }
        public Guid ChatMemberId { get; }   
        public Guid MessageId { get; }  
        public string EditedMessage { get; }

        public EditChatMessageCommand()
        {
            
        }
        public EditChatMessageCommand(
            Guid workId,
            Guid chatMemberId,
            Guid messageID,
            string editedMessage)
        {
            WorkId = workId;
            ChatMemberId = chatMemberId;
            EditedMessage = editedMessage;
            MessageId = messageID;
        }
    }
}
