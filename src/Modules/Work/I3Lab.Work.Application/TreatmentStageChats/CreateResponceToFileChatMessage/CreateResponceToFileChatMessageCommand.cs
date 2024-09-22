using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.TreatmentStageChats.CreateResponceToFileChatMessage
{
    public class CreateResponceToFileChatMessageCommand : IRequest<Result>
    {
        public Guid TreatmentStageChatId { get; set; }
        public Guid MemberId { get; set; }
        public Guid FileId { get; set; }    
        public string Message { get; set; }
        public CreateResponceToFileChatMessageCommand()
        {
            
        }
        public CreateResponceToFileChatMessageCommand(
            Guid treatmentStageChatId,
            Guid memberId,
            Guid fileId,
            string message)
        {
            TreatmentStageChatId = treatmentStageChatId;
            MemberId = memberId;
            FileId = fileId;
            Message = message;
        }
    }
}
