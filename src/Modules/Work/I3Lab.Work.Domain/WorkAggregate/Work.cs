using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Work.Domain.WorkAggregate
{
    public class Work
    {
        public long Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public Guid? FileId { get; private set; }
        public WorkStatus Status { get; private set; }
        public Guid Accessibility { get; private set; }
        public Guid DetailId { get; private set; }

        public Work(long id, Guid customerId, Guid? fileId, WorkStatus status, Guid accessibility, Guid detailId)
        {
            Id = id;
            CustomerId = customerId;
            FileId = fileId;
            Status = status;
            Accessibility = accessibility;
            DetailId = detailId;
        }
    }
}
