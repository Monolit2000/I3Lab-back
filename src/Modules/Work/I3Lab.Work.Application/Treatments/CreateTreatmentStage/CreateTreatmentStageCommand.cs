using FluentResults;
using I3Lab.Works.Domain.Works;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.Treatments.CreateTreatmentStage
{
    public class CreateTreatmentStageCommand : IRequest<Result<TreatmentStageDto>>
    {
        public WorkId WorkId { get; }


        public CreateTreatmentStageCommand(WorkId workId)
        {
            WorkId = workId;
        }
    }
}
