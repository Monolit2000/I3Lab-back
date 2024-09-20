using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.TreatmentInvites.GetAllTreatmentInvitesByTreatmentId
{
    public class TreatmentInviteDto
    {
        public Guid Id { get; set; }
        public string MemberToInviteEmail { get; set; }
        public string InviterEmail { get; set; }
        public string Status { get; set; }
        public DateTime OcurredOn { get; set; }
    }
}
