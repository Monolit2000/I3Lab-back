using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Domain.WorkChats.Events
{
    public class ChatMemberRemovedDamainEvent : DomainEventBase
    {
        public WorkChatId WorkChatId { get; }
        public MemberId MemberId { get; }

        public ChatMemberRemovedDamainEvent(
            WorkChatId workChatId,
            MemberId memberId)
        {
            WorkChatId = workChatId;
            MemberId = memberId;
        }
    }
}
