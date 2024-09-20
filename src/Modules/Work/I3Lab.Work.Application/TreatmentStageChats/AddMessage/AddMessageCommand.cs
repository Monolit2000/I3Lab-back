using MediatR;
using FluentResults;

namespace I3Lab.Treatments.Application.WorkChats.AddMessage
{
    public class AddMessageCommand : IRequest<Result>
    {
        public Guid WorkId {  get; set; }   
        public Guid MemberId { get; set; }  
        public string Message { get; set; }

        public AddMessageCommand(
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
