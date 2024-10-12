using MediatR;
using FluentResults;
using I3Lab.Treatments.Domain.Members;

namespace I3Lab.Treatments.Application.Members.RemoveMember
{
    public class RemoveMemberCommandHandler(IMemberRepository memberRepository) : IRequestHandler<RemoveMemberCommand, Result>
    {
        public async Task<Result> Handle(RemoveMemberCommand request, CancellationToken cancellationToken)
        {
            await memberRepository.DeleteByIdIfExistAsync(new MemberId(request.MemberId), cancellationToken);

            await memberRepository.SaveChangesAsync(cancellationToken);

            return Result.Ok();
        }
    }
}
