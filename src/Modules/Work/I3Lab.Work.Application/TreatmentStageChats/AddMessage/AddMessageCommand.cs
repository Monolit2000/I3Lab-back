using MediatR;
using FluentResults;

namespace I3Lab.Treatments.Application.TreatmentStageChats.AddMessage
{
    public class AddMessageCommand : IRequest<Result>
    {
        public Guid TreatmentStageId {  get; set; }   
        public Guid MemberId { get; set; }  
        public string Message { get; set; }

        public AddMessageCommand(
            Guid treatmentStageIdId,
            Guid memberId, 
            string message)
        {
            TreatmentStageId = treatmentStageIdId;
            MemberId = memberId;    
            Message = message;  
        }
    }
}
