using I3Lab.Works.Domain.TreatmentInvites;
using MediatR;
using FluentResults;

namespace I3Lab.Works.Application.TreatmentInvites.RejectTreatmentInvite
{
    public class RejectTreatmentInviteCommandHandler
      (ITreatmentInviteRepository treatmentInviteRepository) : IRequestHandler<RejectTreatmentInviteCommand, Result>
    {
        public async Task<Result> Handle(RejectTreatmentInviteCommand request, CancellationToken cancellationToken)
        {
            var treatmentInvite = await treatmentInviteRepository.GetByIdAsync(new TreatmentInviteId(request.TreatmentInviteId));

            treatmentInvite.Reject();

            return Result.Ok();
        }
    }
}
