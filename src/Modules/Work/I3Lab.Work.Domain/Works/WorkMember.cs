using I3Lab.Work.Domain.Members;
using I3Lab.Work.Domain.Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Work.Domain.Works
{
    public class WorkMember
    {
        public WorkId WorkId { get; private set; }  
        public MemberId MemberId { get; private set; }  

        public DateTime JoinDate { get; private set; }

        private WorkMember()
        {
        }

        private WorkMember(WorkId workId, MemberId memberId) 
        {
            WorkId = workId;
            MemberId = memberId;
            JoinDate = DateTime.UtcNow;
        }

        public static WorkMember CreateNew(WorkId workId, MemberId memberId)
        {
            return new WorkMember(workId, memberId);
        }

    }
}
