using MediatR;
using FluentResults;
using I3Lab.Treatments.Domain.TreatmentInvites;

namespace I3Lab.Treatments.Application.TreatmentInvites.RejectTreatmentInvite
{
    public class RejectTreatmentInviteCommandHandler
      (ITreatmentInviteRepository treatmentInviteRepository) : IRequestHandler<RejectTreatmentInviteCommand, Result>
    {
        public async Task<Result> Handle(RejectTreatmentInviteCommand request, CancellationToken cancellationToken)
        {
            var treatmentInvite = await treatmentInviteRepository
                .GetByIdAsync(new TreatmentInviteId(request.TreatmentInviteId));
            if (treatmentInvite is null)
                return Result.Fail(TreatmentInviteApplicationErrors.TreatmentInviteNotFound);

            var result = treatmentInvite.Reject();
            if(result.IsFailed)
                return result;

            await treatmentInviteRepository.SaveChangesAsync();
            return result;
        }
    }
}
