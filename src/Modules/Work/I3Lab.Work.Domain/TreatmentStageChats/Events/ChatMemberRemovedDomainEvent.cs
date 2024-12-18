﻿using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Domain.TreatmentStageChats.Events
{
    public class ChatMemberRemovedDomainEvent : DomainEventBase
    {
        public TreatmentStageChatId WorkChatId { get; }
        public MemberId MemberId { get; }

        public ChatMemberRemovedDomainEvent(
            TreatmentStageChatId workChatId,
            MemberId memberId)
        {
            WorkChatId = workChatId;
            MemberId = memberId;
        }
    }
}
