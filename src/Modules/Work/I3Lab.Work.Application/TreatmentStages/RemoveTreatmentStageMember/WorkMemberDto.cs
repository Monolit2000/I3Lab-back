using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.Works.RemoveWorkMember
{
    public class WorkMemberDto
    {
        public Guid WorkId { get; set; }
        public Guid MemberId { get; set; }
        public Guid AddedBy { get; set; }
        public DateTime JoinDate { get; set; }

        public WorkMemberDto(Guid workId, Guid memberId, Guid addedBy, DateTime joinDate)
        {
            WorkId = workId;
            MemberId = memberId;
            AddedBy = addedBy;
            JoinDate = joinDate;
        }
    }
}
