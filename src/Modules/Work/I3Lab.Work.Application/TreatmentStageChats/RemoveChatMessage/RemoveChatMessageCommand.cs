using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.WorkChats.RemoveChatMessage
{
    public class RemoveChatMessageCommand : IRequest<Result>
    {
        public Guid WorkId { get; set; }
        public Guid MemberId { get; set; }
        public Guid MessageId { get; set; }

        public RemoveChatMessageCommand(
            Guid workId,
            Guid memberId,
            Guid messageId)
        {
            WorkId = workId;
            MemberId = memberId;
            MessageId = messageId;
        }
    }
}
