﻿using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Work.Domain.Works.Events
{
    public class WorkCreatedDomainEvent : DomainEventBase
    {
        public WorkId WorkId { get; }

        public WorkCreatedDomainEvent(WorkId workId)
        {
            WorkId = workId;
        }
    }
}