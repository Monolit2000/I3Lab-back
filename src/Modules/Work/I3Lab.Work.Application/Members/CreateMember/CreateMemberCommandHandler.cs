using FluentResults;
using I3Lab.Works.Domain.Members;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.Members.CreateMember
{
    public class CreateMemberCommandHandler(
        IMemberRepository memberRepository) : IRequestHandler<CreateMemberCommand, Result<MemberDto>>
    {

        public async Task<Result<MemberDto>> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            //var newMember = Member.CreateNew();

            return new MemberDto();
        }
    }
}
