using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.Works.CreateWorks
{
    public class WorkDto
    {
        public Guid Id { get; set; }
        public Guid TreatmentId { get; set; }
        public string TreatmentName { get; set; }
        public string WorkStatus { get; set; }
        public DateTime WorkStartedDate { get; set; }
        public Guid CreatorId { get; set; }
        public Guid? CustomerId { get; set; }
        public string WorkAvatarImageUrl { get; set; }

        //public List<WorkMemberDto> WorkMembers { get; set; } = new List<WorkMemberDto>();
        //public List<WorkFileDto> WorkFiles { get; set; } = new List<WorkFileDto>();
    }
}
