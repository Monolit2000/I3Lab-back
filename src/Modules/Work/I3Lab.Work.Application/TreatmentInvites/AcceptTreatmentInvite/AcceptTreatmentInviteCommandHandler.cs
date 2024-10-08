using FluentResults;
using I3Lab.Treatments.Domain.TreatmentInvites;
using MediatR;

namespace I3Lab.Treatments.Application.TreatmentInvites.AcceptTreatmentInvite
{
    public class AcceptTreatmentInviteCommandHandler
        (ITreatmentInviteRepository treatmentInviteRepository) : IRequestHandler<AcceptTreatmentInviteCommand, Result>
    {
        public async Task<Result> Handle(AcceptTreatmentInviteCommand request, CancellationToken cancellationToken)
        {
            var treatmentInvite = await treatmentInviteRepository.GetByIdAsync(new TreatmentInviteId(request.TreatmentInviteId));

            var result = treatmentInvite.Accept();

            if(result.IsFailed)
                return result;  

            await treatmentInviteRepository.SaveChangesAsync();

            return result;
        }
    }
}
