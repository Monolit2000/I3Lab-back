using FluentResults;
using MassTransit.Observables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.Members.RemoveMember
{
    public class RemoveMemberCommand : IRequest<Result>
    {
        public Guid MemberId { get; set; }

        public RemoveMemberCommand(Guid memberId)
        {
            MemberId = memberId;
        }
    }
}
