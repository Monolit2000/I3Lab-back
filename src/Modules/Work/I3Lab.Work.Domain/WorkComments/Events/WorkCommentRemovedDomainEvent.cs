using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.Works;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Domain.WorkComments.Events
{
    public class WorkCommentRemovedDomainEvent : DomainEventBase
    {
        public WorkCommentId WorkCommentId { get; }

        public WorkCommentRemovedDomainEvent(WorkCommentId workCommentId)
        {
            WorkCommentId = workCommentId;
        }
    }
}
