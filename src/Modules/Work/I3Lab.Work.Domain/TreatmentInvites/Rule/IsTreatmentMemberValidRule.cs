using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Domain.TreatmentInvites.Rule
{
    public class IsTreatmentMemberValidRule : IBusinessRule
    {
        private readonly IEnumerable<Member> _validMembers;
        private readonly Member _memberToCheck;

        public IsTreatmentMemberValidRule(IEnumerable<Member> validMembers, Member memberToCheck)
        {
            _validMembers = validMembers;
            _memberToCheck = memberToCheck;
        }

        public bool IsBroken() => !_validMembers.Any(m => m.Id == _memberToCheck.Id);

        public string Message => "The member is not a valid participant in the treatment.";
    }
}
