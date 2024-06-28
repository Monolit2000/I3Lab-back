using I3Lab.BuildingBlocks.Domain;
using I3Lab.Work.Domain.Members;
using I3Lab.Work.Domain.Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Work.Domain.WorkAccebilitys
{
    public class WorkAccebility : Entity, IAggregateRoot
    {
        public WorkAccebilityId Id { get; private set; }
        public WorkId WorkId { get; private set; }

        public readonly List<WorkAccebilityMember> WorkMembers = [];

        public WorkAccebility(WorkId workId)
        {
            Id = new WorkAccebilityId(Guid.NewGuid());
            WorkId = workId;   
        }

        public static WorkAccebility CreateNew(WorkId workId)
        {
            var newWorkAccebility = new WorkAccebility(workId);

            return newWorkAccebility;
        }

        public void JoinToWorkAccebility(MemberId memberId)
        {
           
        }

    }
}
