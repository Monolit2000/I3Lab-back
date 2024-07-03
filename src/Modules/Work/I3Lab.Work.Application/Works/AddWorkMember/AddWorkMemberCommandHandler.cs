using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Work.Application.Works.AddWorkMember
{
    public class AddWorkMemberCommandHandler : IRequestHandler<AddWorkMemberCommand, Result<WorkMemberDto>>
    {
        public Task<Result<WorkMemberDto>> Handle(AddWorkMemberCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
