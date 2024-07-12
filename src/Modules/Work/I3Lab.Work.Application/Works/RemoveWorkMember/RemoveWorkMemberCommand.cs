using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.Works.RemoveWorkMember
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
