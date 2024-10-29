using MediatR;
using FluentResults;
using I3Lab.Treatments.Domain.TreatmentStages;

namespace I3Lab.Treatments.Application.TreatmentStages.CloseTreatmentStage
{
    public class CloseTreatmentStageCommandHandler(
        ITreatmentStageRepository treatmentStageRepository) : IRequestHandler<CloseTreatmentStageCommand, Result>
    {
        public async Task<Result> Handle(CloseTreatmentStageCommand request, CancellationToken cancellationToken)
        {
            var treatmentStage = await treatmentStageRepository.GetByIdAsync(new TreatmentStageId(request.TreatmentStageId));
            if (treatmentStage is null)
                return Result.Fail(TreatmentStageApplicationErrors.TratmentStageNotFound);

            var result = treatmentStage.Close();
            if(result.IsFailed)
                return result;  

            return result;
        }
    }
}
