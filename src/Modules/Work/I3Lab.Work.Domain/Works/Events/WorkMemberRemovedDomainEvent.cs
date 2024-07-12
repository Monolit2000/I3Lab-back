using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Domain.Works.Events
{
    public class WorkMemberRemovedDomainEvent : DomainEventBase
    {
        public WorkId WorkId { get; }
        public MemberId MemberId { get; }
        public MemberId RemovedBy { get; }

        public WorkMemberRemovedDomainEvent(
            WorkId workId,
            MemberId memberId, 
            MemberId removedBy)
        {
            WorkId = workId;
            MemberId = memberId;
            RemovedBy = removedBy;
        }
    }
}
