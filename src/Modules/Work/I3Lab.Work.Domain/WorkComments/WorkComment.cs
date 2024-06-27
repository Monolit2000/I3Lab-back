using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Work.Domain.WorkComments
{
    public class WorkComment : Entity, IAggregateRoot
    {
        public WorkCommentId Id { get; private set; }

        public Guid AuthorId { get; private set; }  

        public Guid WorkId { get; private set; }
        public string Text { get; private set; }

        public WorkComment(WorkCommentId id, Guid workId, string text)
        {
            Id = new WorkCommentId(Guid.NewGuid());
            WorkId = workId;
            Text = text;
        }
    }
}
