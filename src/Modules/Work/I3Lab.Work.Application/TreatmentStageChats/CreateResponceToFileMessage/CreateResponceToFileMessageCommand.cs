using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.TreatmentStageChats.CreateResponceToFileMessage
{
    public class CreateResponceToFileMessageCommand : IRequest<Result<ResponceToFileMessageDto>>
    {
        public Guid WorkId { get; set; }
        public Guid MemberId { get; set; }
        public Guid FileId { get; set; }    
        public string Message { get; set; }

        public CreateResponceToFileMessageCommand(
            Guid workId,
            Guid memberId,
            string message)
        {
            WorkId = workId;
            MemberId = memberId;
            Message = message;
        }
    }
}
