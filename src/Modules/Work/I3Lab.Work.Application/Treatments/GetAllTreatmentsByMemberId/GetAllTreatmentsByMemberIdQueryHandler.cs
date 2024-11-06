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
                TreatmentId = treatment.Id.Value,
                Title = treatment.Titel.Value,
                Status = treatment.Status.Value,
                CreatorId = treatment.Creator.Id.Value,
                PatientId = treatment.Patient.Id.Value,
                InviteToken = treatment.InvitationToken?.Token,
                TreatmentDate = treatment.TreatmentDate.TreatmentStarted
            }).ToList();
        }
    }
}

