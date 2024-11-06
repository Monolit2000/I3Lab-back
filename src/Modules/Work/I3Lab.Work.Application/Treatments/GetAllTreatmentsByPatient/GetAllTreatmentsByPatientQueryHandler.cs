using MediatR;
using FluentResults;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments;


namespace I3Lab.Treatments.Application.Treatments.GetAllTreatmentsByPatient
{
    public class GetAllTreatmentsByPatientQueryHandler(
        ITreatmentRepository treatmentRepository) : IRequestHandler<GetAllTreatmentsByPatientQuery, Result<List<TreatmentDto>>>
    {
        public async Task<Result<List<TreatmentDto>>> Handle(GetAllTreatmentsByPatientQuery request, CancellationToken cancellationToken)
        {
            var treatments = await treatmentRepository.GetAllByMemberIdAsync(new MemberId(request.PatientId));

            if (treatments == null || !treatments.Any())
                return Result.Fail("No treatments found for the patient.");

            var treatmentDtos = treatments.Select(t => new TreatmentDto
            {
                TreatmentId = t.Id.Value,
                Title = t.Titel.Value,
                Status = t.Status.Value,
                CreatorId = t.Creator.Id.Value,
                PatientId = t.Patient.Id.Value,
                TreatmentDate = t.TreatmentDate.TreatmentStarted
            }).ToList();

            return Result.Ok(treatmentDtos);
        }
    }
}
