using I3Lab.BuildingBlocks.Domain;
using I3Lab.Work.Domain.Members;
using I3Lab.Work.Domain.WorkAccebilitys;
using I3Lab.Work.Domain.WorkComments;
using I3Lab.Work.Domain.Works;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Work.Domain.Work
{
    public class Work : Entity, IAggregateRoot
    {
        public readonly List<WorkFile> WorkFiles = [];

        public readonly List<WorkMember> WorkMembers = [];

        public WorkId Id { get; private set; }
        public MemberId CustomerId { get; private set; }
        public WorkStatus Status { get; private set; }
        public WorkAccebility Accessibility { get; private set; }

        public MemberId CreatorId { get; private set; }

        public Guid DetailId { get; private set; }

        private Work()
        {
            //Ef core
        }
        private Work(Guid detailId)
        {
            Id = new WorkId(Guid.NewGuid());
            Status = WorkStatus.Pending;
            DetailId = detailId;
            Accessibility = WorkAccebility.CreateNew(this.Id);
        }

        public static Work CreateNewWork(Guid detailId)
        {
            var newWork = new Work(detailId);

            return newWork;
        }

        public void AddWorkFile()
        {
            
        }

        

    }
}
