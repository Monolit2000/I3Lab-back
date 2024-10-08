using MediatR;
using FluentResults;
using I3Lab.Treatments.Domain.TreatmentInvites;

namespace I3Lab.Treatments.Application.TreatmentInvites.AcceptTreatmentIInviteByLink
{
    public class AcceptTreatmentIInviteByLinkCommandHandler(
        ITreatmentInviteRepository treatmentInviteRepository) : IRequestHandler<AcceptTreatmentIInviteByLinkCommand, Result>
    {
        public async Task<Result> Handle(AcceptTreatmentIInviteByLinkCommand request, CancellationToken cancellationToken)
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
