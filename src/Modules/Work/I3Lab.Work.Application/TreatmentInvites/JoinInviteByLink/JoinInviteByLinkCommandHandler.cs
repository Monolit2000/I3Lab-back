using FluentResults;
using I3Lab.Treatments.Domain.TreatmentInvites;
using MediatR;

namespace I3Lab.Treatments.Application.TreatmentInvites.JoinInviteByLink
{
    public class JoinInviteByLinkCommandHandler(ITreatmentInviteRepository treatmentInviteRepository) : IRequestHandler<JoinInviteByLinkCommand, Result>
    {
        public async Task<Result> Handle(JoinInviteByLinkCommand request, CancellationToken cancellationToken)
        {
            var invite = await treatmentInviteRepository.GetByTokenAsync(request.Token);

            if (invite == null)
                return Result.Fail("Invalid invite link.");

            var result = invite.ValidateInviteToken(request.Token);

            if (result.IsFailed)
                return result;

            return invite.Accept();
        }
    }
}
