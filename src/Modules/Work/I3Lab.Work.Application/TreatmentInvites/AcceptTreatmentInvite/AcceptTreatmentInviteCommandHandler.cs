using MediatR;
using FluentResults;
using I3Lab.Treatments.Domain.TreatmentInvites;

namespace I3Lab.Treatments.Application.TreatmentInvites.AcceptTreatmentInvite
{
    public class AcceptTreatmentInviteCommandHandler
        (ITreatmentInviteRepository treatmentInviteRepository) : IRequestHandler<AcceptTreatmentInviteCommand, Result>
    {
        public async Task<Result> Handle(AcceptTreatmentInviteCommand request, CancellationToken cancellationToken)
        {
            var treatmentInvite = await treatmentInviteRepository
                .GetByIdAsync(new TreatmentInviteId(request.TreatmentInviteId));
            if (treatmentInvite is null)
                return Result.Fail(TreatmentInviteApplicationErrors.TreatmentInviteNotFound);

            var result = treatmentInvite.Accept();
            if(result.IsFailed)
                return result;  

            await treatmentInviteRepository.SaveChangesAsync();

            return result;
        }
    }
}
