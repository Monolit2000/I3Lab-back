using I3Lab.BuildingBlocks.Domain;
using I3Lab.Work.Domain.Works;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Work.Domain.WorkComments.Events
{
    public class WorkCommentAddedDomainEvent : DomainEventBase
    {
        public WorkCommentId WorkCommentId { get; }

        public WorkId WorkId { get; }

        public string Comment { get; }

        public WorkCommentAddedDomainEvent(WorkCommentId workCommentId, WorkId workId, string comment)
        {
            WorkCommentId = workCommentId;  
            WorkId = workId;
            Comment = comment;
        }
    }
}
