using FluentResults;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.TreatmentInvites;
using I3Lab.Treatments.Domain.Treatments;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.Treatments.GetAllTreatmentsByPatient
{
    public class GetAllTreatmentsByPatientQueryHandler(
        ITreatmentRepository treatmentRepository) : IRequestHandler<GetAllTreatmentsByPatientQuery, Result<List<TreatmentDto>>>
    {
        public async Task<Result<List<TreatmentDto>>> Handle(GetAllTreatmentsByPatientQuery request, CancellationToken cancellationToken)
        {
            var treatments = await treatmentRepository.GetAllByPatientAsync(new MemberId(request.PatientId));

            if (treatments == null || !treatments.Any())
                return Result.Fail("No treatments found for the patient.");

            var treatmentDtos = treatments.Select(t => new TreatmentDto
            {
                Id = t.Id.Value,
                Title = t.Titel.Value,
                IsCanceled = t.IsCanceled,
                IsFinished = t.IsFinished,
                TreatmentDate = t.TreatmentDate.TreatmentStarted,
                CreatorId = t.Creator.Id.Value,
                PatientId = t.Patient.Id.Value
            }).ToList();

            return Result.Ok(treatmentDtos);
        }
    }
}
