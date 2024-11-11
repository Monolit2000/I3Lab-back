using FluentResults;
using I3Lab.Treatments.Domain.TreatmentStages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.TreatmentStageChats.EditChatMessage
{
    public class EditChatMessageCommand : IRequest<Result>
    {
        public Guid TreatmentStageId { get; set; }
        public Guid EditorId { get; set; }   
        public Guid MessageId { get; set; }  
        public string EditedMessage { get; set; }

        public EditChatMessageCommand()
        {
            
        }
        public EditChatMessageCommand(
            Guid treatmentStageId,
            Guid chatMemberId,
            Guid messageID,
            string editedMessage)
        {
            TreatmentStageId = treatmentStageId;
            EditorId = chatMemberId;
            EditedMessage = editedMessage;
            MessageId = messageID;
        }
    }
}
