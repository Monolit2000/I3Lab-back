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
        public WorkAccebilityId WorkAccebilityId { get; private set; }

        public readonly List<WorkFile> WorkFiles = [];

        public readonly List<WorkMember> WorkMembers = [];

        public WorkId Id { get; private set; }
        public WorkFile WorkAvatarImage  { get; private set; }
        public MemberId CustomerId { get; private set; }
        public WorkStatus Status { get; private set; }
        public MemberId CreatorId { get; private set; }
        public DateTime WorkStarted { get; private set; }   

        private Work()
        {
            //Ef core
        }
        private Work(MemberId creatorId, WorkAccebilityId workAccebilityId)
        {
            Id = new WorkId(Guid.NewGuid());
            Status = WorkStatus.Pending;
            CreatorId = creatorId;
            WorkAccebilityId = workAccebilityId;
            WorkStarted = DateTime.UtcNow;
        }

        public static Work CreateNewWork(MemberId creatorId, WorkAccebilityId workAccebilityId)
        {
            var newWork = new Work(creatorId, workAccebilityId);

            return newWork;
        }

        public void AddWorkFile()
        {
            
        }

        

    }
}
