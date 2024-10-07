using FluentResults;
using I3Lab.Treatments.Application.Contract;
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

        //public string CacheKey => throw new NotImplementedException();
    }
}
