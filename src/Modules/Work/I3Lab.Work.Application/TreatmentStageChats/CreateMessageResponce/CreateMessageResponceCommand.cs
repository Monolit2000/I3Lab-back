using MediatR;
using FluentResults;

namespace I3Lab.Treatments.Application.TreatmentStageChats.CreateMessageResponce
{
    public class CreateMessageResponceCommand : IRequest<Result>
    {
        public Guid TreatmentStageId { get; set; }
        public Guid SenderId { get; set; }
        public Guid MessageId { get; set; } 
        public string Message { get; set; }

        public CreateMessageResponceCommand(
            Guid treatmentStageId,
            Guid memberId,
            string message)
        {
            TreatmentStageId = treatmentStageId;
            SenderId = memberId;
            Message = message;
        }

    }
}
