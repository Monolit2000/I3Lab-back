using FluentResults;
using I3Lab.Works.Domain.Treatments;
using MediatR;

namespace I3Lab.Works.Application.Treatments.GetTreatmentById
{
    public class GetTreatmentByIdQueryHandler(ITretmentRepository treatmentRepository) : IRequestHandler<GetTreatmentByIdQuery, Result<TreatmentDto>>
    {
        public async Task<Result<TreatmentDto>> Handle(GetTreatmentByIdQuery request, CancellationToken cancellationToken)
        {
            var treatment = await treatmentRepository.GetByIdAsync( new TreatmentId(request.TreatmentId), cancellationToken);

            if (treatment == null)
                return Result.Fail<TreatmentDto>("Treatments not found");

            var treatmentDto = new TreatmentDto
            {
                Id = treatment.Id.Value,
                CreatorId = treatment.CreatorId.Value,
                PatientId = treatment.PatientId.Value,
                Name = treatment.Name,
                CreateDate = treatment.CreateDate,
                TreatmentPreview = treatment.TreatmentPreview.Value,
                TreatmentStages = treatment.TreatmentStages.Select(stage => new TreatmentStageDto
                {
                    Id = stage.Id.Value,
                }).ToList()
            };

            return Result.Ok(treatmentDto);
        }
    }
}
