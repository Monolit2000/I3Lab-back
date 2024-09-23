using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.Treatments.FinishTreatment
{
    public class FinishTreatmentCommand : IRequest<Result>
    {
        public Guid UserId { get; set; }
        public Guid TreatmentId { get; set; }

        public FinishTreatmentCommand(
            Guid userId, 
            Guid treatmentId)
        {
            UserId = userId;
            TreatmentId = treatmentId;
        }
    }
}
