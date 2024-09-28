using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Domain.Treatments.Rules
{
    public class MemberMustNotBeInTreatmentRule : IBusinessRule
    {
        private readonly List<TreatmentMember> _members;
        private readonly MemberId _memberId;

        public MemberMustNotBeInTreatmentRule(List<TreatmentMember> members, MemberId memberId)
        {
            _members = members;
            _memberId = memberId;
        }

        public bool IsBroken() => _members.Any(m => m.Member.Id == _memberId);

        public string Message => "Member is already added to the treatment.";
    }

}
