using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Work.Domain.Works.Events
{
    public class WorkStatusChangedDomainEvent : DomainEventBase
    {
        public WorkId WorkId{ get; }
        public WorkStatus NewStatus { get; }

        public WorkStatusChangedDomainEvent(WorkId workId, WorkStatus newStatus)
        {
            WorkId = workId;
            NewStatus = newStatus;
        }
    }
}
