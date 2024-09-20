using FluentResults;
using MediatR;

namespace I3Lab.Treatments.Application.Works.RemoveWorkMember
{
    public class RemoveWorkMemberCommand : IRequest<Result<WorkMemberDto>>
    {
        public Guid WorkId { get; set; }
        public Guid MemberId { get; set; }

        public RemoveWorkMemberCommand(Guid workId, Guid memberId)
        {
            WorkId = workId;
            MemberId = memberId;
        }
    }
}
