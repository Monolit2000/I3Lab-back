using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.TreatmentStages.CloseTreatmentStage
{
    public class CloseTreatmentStageCommand : IRequest<Result>
    {
        public Guid TreatmentStageId { get; set; }
    }
}
