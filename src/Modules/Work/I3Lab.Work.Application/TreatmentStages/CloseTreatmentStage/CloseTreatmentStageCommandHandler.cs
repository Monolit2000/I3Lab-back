using MediatR;
using FluentResults;
using I3Lab.Treatments.Domain.TreatmentStages;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace I3Lab.Treatments.Application.TreatmentStages.CloseTreatmentStage
{
    public class CloseTreatmentStageCommandHandler(
        ITreatmentStageRepository treatmentStageRepository) : IRequestHandler<CloseTreatmentStageCommand, Result>
    {
        public async Task<Result> Handle(CloseTreatmentStageCommand request, CancellationToken cancellationToken)
        {
            var treatmentStage = await treatmentStageRepository.GetByIdAsync(new TreatmentStageId(request.TreatmentStageId));

            var result = treatmentStage.Close();

            return result;
        }
    }
}
