using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.Works;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Domain.WorkComments.Events
{
    public class WorkCommentEditedDomainEvent : DomainEventBase
    {
        public WorkCommentId WorkCommentId { get; }

        public string EditedComment { get; }

        public WorkCommentEditedDomainEvent(WorkCommentId workCommentId, string editedComment)
        {
            WorkCommentId = workCommentId;
            EditedComment = editedComment;
        }
    }
}
