using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Work.Domain.WorkAggregate
{
    public class Work
    {
        public WorkId Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public Guid? FileId { get; private set; }
        public WorkStatus Status { get; private set; }
        public Guid Accessibility { get; private set; }
        public Guid DetailId { get; private set; }

        public Work(WorkId id, Guid customerId, Guid? fileId, Guid accessibility, Guid detailId)
        {
            Id = new WorkId(Guid.NewGuid());
            CustomerId = customerId;
            FileId = fileId;
            Status = WorkStatus.Pending;
            Accessibility = accessibility;
            DetailId = detailId;
        }
    }
}
