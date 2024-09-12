using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Domain.WorkChats.Events
{
    public class ReplyToChatMessageCreatedDomainEvent : DomainEventBase
    {
        public Guid RepliedToMessageId { get; }

        public ReplyToChatMessageCreatedDomainEvent(Guid repliedToMessageId)
        {
            RepliedToMessageId = repliedToMessageId;
        }
    }
}
