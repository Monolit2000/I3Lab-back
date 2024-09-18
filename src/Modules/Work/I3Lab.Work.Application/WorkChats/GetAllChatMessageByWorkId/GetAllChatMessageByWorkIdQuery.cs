using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.WorkChats.GetAllChatMessageByWorkId
{
    public class GetAllChatMessageByWorkIdQuery : IRequest<Result<List<ChatMessageDto>>>
    {
        public Guid WorkId { get; set; }

        public GetAllChatMessageByWorkIdQuery()
        {
                
        }
        public GetAllChatMessageByWorkIdQuery(Guid workId)
        {
            WorkId = workId;
        }

    }
}
