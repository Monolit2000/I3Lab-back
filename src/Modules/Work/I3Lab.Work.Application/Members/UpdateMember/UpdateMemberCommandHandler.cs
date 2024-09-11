using MediatR;
using FluentResults;
using I3Lab.Works.Domain.Members;

namespace I3Lab.Works.Application.Members.UpdateMember
{
    public class UpdateMemberCommandHandler(
        IMemberRepository memberRepository) : IRequestHandler<UpdateMemberCommand, Result>
    {
        public async Task<Result> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
        {
            var member = await memberRepository.GetMemberByIdAsync(new MemberId(request.MemberId));

            throw new NotImplementedException();
        }
    }
}
