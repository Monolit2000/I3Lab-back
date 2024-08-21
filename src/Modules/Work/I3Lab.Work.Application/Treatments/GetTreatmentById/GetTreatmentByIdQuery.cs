using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.Treatments.GetTreatmentById
{
    public class GetTreatmentByIdQuery : IRequest<Result<TreatmentDto>>
    {
        public Guid TreatmentId { get; }

        public GetTreatmentByIdQuery(Guid treatmentId)
        {
            TreatmentId = treatmentId;
        }
    }
}
