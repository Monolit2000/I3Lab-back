using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.TreatmentStageChats.GetTreatmentStageChatByTreatmentId
{
    public class GetTreatmentStageChatByTreatmentIdQuery : IRequest<Result<List<TreatmentStageChatDto>>>
    {
        public Guid TreatmentId { get; set; }

        public GetTreatmentStageChatByTreatmentIdQuery()
        {
                
        }

        public GetTreatmentStageChatByTreatmentIdQuery(Guid treatmentId)
        {
            TreatmentId = treatmentId;
        }
    }
}
