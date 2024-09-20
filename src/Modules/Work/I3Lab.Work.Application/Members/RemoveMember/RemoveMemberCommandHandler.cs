using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.Members.RemoveMember
{
    public class RemoveMemberCommandHandler : IRequestHandler<RemoveMemberCommand, Result>
    {
        public Task<Result> Handle(RemoveMemberCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
