using FluentResults;
using I3Lab.Treatments.Domain.Treatments;
using MediatR;

namespace I3Lab.Treatments.Application.Treatments.GetAllTreatment
{
    public class GetAllTreatmentQueryHandler(
        ITreatmentRepository treatmentRepository) : IRequestHandler<GetAllTreatmentQuery, Result<List<TreatmentDto>>>
    {
        public async Task<Result<List<TreatmentDto>>> Handle(GetAllTreatmentQuery request, CancellationToken cancellationToken)
        {
            var treatmens = await treatmentRepository.GetAllAsync();

            if (treatmens.Any() is false)
                return new List<TreatmentDto>();

            return treatmens.Select(treatment => new TreatmentDto
            {
                Id = treatment.Id.Value,
                CreatorId = treatment.Creator.Id.Value,
                PatientId = treatment.Patient.Id.Value,
            }).ToList();
        }
    }
}
