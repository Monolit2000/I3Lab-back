using MediatR;
using FluentResults;
using I3Lab.Treatments.Domain.Members;
using Microsoft.Extensions.Caching.Distributed;
using I3Lab.BuildingBlocks.Infrastructure.Cache;
using Microsoft.Extensions.Caching.Memory;

namespace I3Lab.Treatments.Application.Members.GetAllMembers
{
    public class GetAllMembersQueryHandler(
        IMemberRepository memberRepository) : IRequestHandler<GetAllMembersQuery, List<MemberDto>>
    {
        public async Task<List<MemberDto>> Handle(GetAllMembersQuery request, CancellationToken cancellationToken)
        {
            var members = await memberRepository.GetAllAsync();

            var membersDto = members.Select(x => new MemberDto
            {
                Id = x.Id.Value,
                Email = x.Email
            }).ToList();

            return membersDto;
        }
    }
}
