using FluentResults;
using I3Lab.Treatments.Domain.Members;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.Members.GetAllMembers
{
    public class GetAllMembersQueryHandler(
        IMemberRepository memberRepository) : IRequestHandler<GetAllMembersQuery, Result<List<MemberDto>>>
    {
        public async Task<Result<List<MemberDto>>> Handle(GetAllMembersQuery request, CancellationToken cancellationToken)
        {
            var members = await memberRepository.GetAllAsync();

            return members.Select(x => new MemberDto 
            {
                Id = x.Id.Value,
                Email = x.Email
            }).ToList();

            throw new NotImplementedException();
        }
    }
}
