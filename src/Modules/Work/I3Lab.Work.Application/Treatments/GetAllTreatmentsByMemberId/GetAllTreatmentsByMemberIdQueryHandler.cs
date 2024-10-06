using MediatR;
using FluentResults;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments;

namespace I3Lab.Treatments.Application.Treatments.GetAllTreatmentsByMemberId
{
    public class GetAllTreatmentsByMemberIdQueryHandler(
        ITreatmentRepository treatmentRepository) : IRequestHandler<GetAllTreatmentsByMemberIdQuery, Result<List<TreatmentDto>>>
    {
        public async Task<Result<List<TreatmentDto>>> Handle(GetAllTreatmentsByMemberIdQuery request, CancellationToken cancellationToken)
        {
            var treatments = await treatmentRepository.GetAllByMemberIdAsync(new MemberId(request.UserId), cancellationToken);

            if(treatments.Any() is false)
                return new List<TreatmentDto>();

            return treatments.Select(treatment => new TreatmentDto
            {
                Id = treatment.Id.Value,
                Title = treatment.Titel.Value,
                Status = treatment.Status.ToString(),
                TreatmentDate = treatment.TreatmentDate.TreatmentStarted,
                CreatorId = treatment.Creator.Id.Value,
                PatientId = treatment.Patient.Id.Value,
                IvniteToken = treatment.InvitationToken?.Token
            }).ToList();
        }
    }
}

