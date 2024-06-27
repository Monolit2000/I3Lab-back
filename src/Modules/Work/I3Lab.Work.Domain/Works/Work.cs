using I3Lab.BuildingBlocks.Domain;
using I3Lab.Work.Domain.WorkComments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Work.Domain.Work
{
    public class Work : Entity, IAggregateRoot
    {
        public WorkId Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public Guid? FileId { get; private set; }
        public WorkStatus Status { get; private set; }


        public List<WorkComment> WorkComments { get; private set; }

        public Guid Accessibility { get; private set; }
        public Guid DetailId { get; private set; }

        private Work()
        {
            //Ef core
        }

        private Work(
            WorkId id,
            Guid customerId, 
            Guid? fileId, 
            Guid accessibility,
            Guid detailId)
        {
            Id = new WorkId(Guid.NewGuid());
            CustomerId = customerId;
            FileId = fileId;
            Status = WorkStatus.Pending;
            Accessibility = accessibility;
            DetailId = detailId;
        }

        public static Work CreateNewWork(
            WorkId id,
            Guid customerId, Guid? fileId, Guid accessibility, Guid detailId)
        {
            var newWork = new Work(id, customerId, fileId, accessibility, detailId);

            return newWork;
        }
    }
}
