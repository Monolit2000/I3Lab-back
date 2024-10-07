using FluentResults;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Domain.TreatmentStages;
using MediatR;
using System.Linq;


namespace I3Lab.Treatments.Application.TreatmentStages.GetTreatmentStageByTreatmentId
{
    public class GetTreatmentStageByTreatmentIdQueryHandler(
        ITreatmentStageRepository treatmentStageRepository) : IRequestHandler<GetTreatmentStageByTreatmentIdQuery, Result<List<TreatmentStageDto>>>
    {
        public async Task<Result<List<TreatmentStageDto>>> Handle(GetTreatmentStageByTreatmentIdQuery request, CancellationToken cancellationToken)
        {
            var treatmentStages = await treatmentStageRepository.GetAllByTreatmentIdAsync(new TreatmentId(request.TreatmentId));

            if (treatmentStages.Any() is false)
                return new List<TreatmentStageDto>();

            var treatmentStageDtos = treatmentStages
                .OrderBy(x => x.TreatmentStageDate.StageStarted)
                .Select(s => new TreatmentStageDto(
                    s.TreatmentId.Value, 
                    s.Id.Value, 
                    s.Titel.Value,
                    s.TreatmentStageStatus.Value))
                .ToList();

            return treatmentStageDtos;
        }
    }
}
