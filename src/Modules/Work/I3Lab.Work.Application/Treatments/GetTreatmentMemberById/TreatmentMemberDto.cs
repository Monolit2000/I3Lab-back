using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.Treatments.GetTreatmentMembers
{
    public class TreatmentMemberDto
    {
        public Guid MemberId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public TreatmentMemberDto(Guid memberId, string firstName, string lastName)
        {
            MemberId = memberId;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
