using FluentResults;
using I3Lab.Treatments.Domain.Members;
using MediatR;

namespace I3Lab.Treatments.Application.Members.CreateMember
{
    public class CreateMemberCommandHandler(
        IMemberRepository memberRepository) : IRequestHandler<CreateMemberCommand, Result<MemberDto>>
    {
        public async Task<Result<MemberDto>> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            if (await memberRepository.IsEmailTakenAsync(request.Email))
                return Result.Fail("Email is already taken");

            var newMember = Member.Create(
                new MemberId(request.UserId),
                request.Email); 

            await memberRepository.AddAsync(newMember);
            await memberRepository.SaveChangesAsync();

            var memberDto = new MemberDto
            {
                Id = newMember.Id.Value,
                Email = newMember.Email,
            };

            return Result.Ok(memberDto);
        }
    }
}
