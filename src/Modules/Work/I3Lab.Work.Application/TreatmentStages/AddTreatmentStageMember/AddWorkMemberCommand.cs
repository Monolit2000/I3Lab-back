using MediatR;
using FluentResults;
using System.Text.Json.Serialization;

namespace I3Lab.Treatments.Application.Works.AddWorkMember
{
    public class AddWorkMemberCommand : IRequest<Result<WorkMemberDto>> 
    {
        public Guid WorkId { get; set; }
        public Guid MemberId { get; set; }
        public Guid AddedByMemberId { get; set; }

        [JsonConstructor]
        public AddWorkMemberCommand(
            Guid workId, 
            Guid workMemberId,
            Guid addedByMemberId)
        {
            WorkId = workId;
            MemberId = workMemberId;
            AddedByMemberId = addedByMemberId;  
        }
    }
}
