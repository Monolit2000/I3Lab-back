using FluentResults;
using I3Lab.Treatments.Domain.Treatments;
using MediatR;

namespace I3Lab.Treatments.Application.Treatments.GetTreatmentById
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
                CreatorId = treatment.Creator.Id.Value,
                PatientId = treatment.Patient.Id.Value,
                Name = treatment.Titel.Value,
                CreateDate = treatment.TreatmentDate.TreatmentStarted,
                TreatmentStages = new List<TreatmentStageDto>()
            };

            return Result.Ok(treatmentDto);
        }
    }
}
