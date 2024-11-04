using MediatR;
using FluentResults;
using I3Lab.Treatments.Domain.Treatments;

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
                Title = treatment.Titel.Value,
                Status = treatment.Status.Value,
                TreatmentDate = treatment.TreatmentDate.TreatmentStarted,
                CreatorId = treatment.Creator.Id.Value,
                PatientId = treatment.Patient.Id.Value,
                InviteToken = treatment.InvitationToken?.Token
            }).ToList();
        }
    }
}
