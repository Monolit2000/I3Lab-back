using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.Members.UpdateMember
{
    public class UpdateMemberCommand : IRequest<Result>
    {
        public Guid MemberId { get; }

        public UpdateMemberCommand(Guid memberId)
        {
            MemberId = memberId;
        }
    }
}
