using FluentResults;
using I3Lab.Treatments.Domain.TreatmentStages;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.TreatmentStages.CreateTreatmentStage
{
    public class CreateTreatmentStageCommand : IRequest<Result<TreatmentStageDto>>
    {
        public TreatmentStageId WorkId { get; }


        public CreateTreatmentStageCommand(TreatmentStageId workId)
        {
            WorkId = workId;
        }
    }
}
