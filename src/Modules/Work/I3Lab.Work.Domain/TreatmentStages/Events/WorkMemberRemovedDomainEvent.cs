﻿using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Domain.TreatmentStages.Events
{
    public class WorkMemberRemovedDomainEvent : DomainEventBase
    {
        public TreatmentStageId WorkId { get; }
        public MemberId MemberId { get; }
        public MemberId RemovedBy { get; }

        public WorkMemberRemovedDomainEvent(
            TreatmentStageId workId,
            MemberId memberId, 
            MemberId removedBy)
        {
            WorkId = workId;
            MemberId = memberId;
            RemovedBy = removedBy;
        }
    }
}
