using I3Lab.BuildingBlocks.Domain;
using I3Lab.Work.Domain.Member;
using I3Lab.Work.Domain.Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Work.Domain.WorkAccebility
{
    public class WorkAccebility : Entity, IAggregateRoot
    {
        public Guid WorkAccebilityId { get; private set; }
        public WorkId WorkId { get; private set; }

        public readonly List<WorkMember> WorkMembers = [];


    }
}
