using FluentResults;
using I3Lab.Treatments.Domain.Treatments;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.Treatments.GetAllTreatmentsByPatient
{
    public class GetAllTreatmentsByPatientQuery : IRequest<Result<List<TreatmentDto>>>
    {
        public Guid PatientId { get; set; }

        public GetAllTreatmentsByPatientQuery()
        {
            
        }

        public GetAllTreatmentsByPatientQuery(Guid patientId)
        {
            PatientId = patientId;
        }
    }
}
