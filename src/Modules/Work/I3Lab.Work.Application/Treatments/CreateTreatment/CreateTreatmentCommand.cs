using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.Treatments.CreateTreatment
{
    public class CreateTreatmentCommand : IRequest<Result<TreatmentDto>>
    {
        public Guid PatientId { get; set; }

        public string TreatmentName { get; set; }
    }
}
