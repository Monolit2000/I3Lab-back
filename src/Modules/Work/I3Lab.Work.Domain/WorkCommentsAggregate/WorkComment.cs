using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Work.Domain.WorkCommentsAggregate
{
    public class WorkComment
    {
        public Guid Id { get; private set; }
        public Guid WorkId { get; private set; }
        public string Text { get; private set; }

        public WorkComment(Guid id, Guid workId, string text)
        {
            Id = id;
            WorkId = workId;
            Text = text;
        }
    }
}
