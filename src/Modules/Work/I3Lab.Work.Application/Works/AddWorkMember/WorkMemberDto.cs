using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.Works.AddWorkMember
{
    public class WorkMemberDto
    {
        public Guid WorkId { get; private set; }
        public Guid MemberId { get; private set; }
        //public Guid AddedBy { get; private set; }
        //public DateTime JoinDate { get; private set; }
        //public string AccessibilityType { get; private set; }

        public WorkMemberDto(
            Guid workId, 
            Guid memberId)
        {
            WorkId = workId;
            MemberId = memberId;
        }
    }
}
