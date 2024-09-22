using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.TreatmentStageChats.GetAllChatMessageByWorkId
{
    public class GetAllChatMessageByTreatmentStageIdQuery : IRequest<Result<List<ChatMessageDto>>>
    {
        public Guid WorkId { get; set; }

        public GetAllChatMessageByTreatmentStageIdQuery()
        {
                
        }
        public GetAllChatMessageByTreatmentStageIdQuery(Guid workId)
        {
            WorkId = workId;
        }

    }
}
