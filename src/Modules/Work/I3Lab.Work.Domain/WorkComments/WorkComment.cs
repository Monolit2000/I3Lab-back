using I3Lab.BuildingBlocks.Domain;
using I3Lab.Work.Domain.Members;
using I3Lab.Work.Domain.Work;
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
        public MemberId AuthorId { get; private set; }  
        public WorkId WorkId { get; private set; }
        public string Content { get; private set; }

        private WorkComment()
        {
        }
        private WorkComment( WorkId workId, MemberId authorId, string content)
        {
            Id = new WorkCommentId(Guid.NewGuid());
            WorkId = workId;
            AuthorId = authorId;
            Content = content;
        }

        internal static WorkComment CreateNew(WorkId workId, MemberId authorId, string content) 
        { 
            return new WorkComment(
                workId,
                authorId,
                content); 
        }
    }
}
