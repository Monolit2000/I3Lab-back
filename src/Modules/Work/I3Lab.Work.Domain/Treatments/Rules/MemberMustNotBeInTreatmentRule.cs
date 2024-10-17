using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments.Errors;

namespace I3Lab.Treatments.Domain.Treatments.Rules
{
    public class MemberMustNotBeInTreatmentRule : IBusinessRule
    {
        private readonly MemberId _memberId;
        private readonly List<TreatmentMember> _members;

        public MemberMustNotBeInTreatmentRule(List<TreatmentMember> members, MemberId memberId)
        {
            _members = members;
            _memberId = memberId;
        }

        public bool IsBroken() => _members.Any(m => m.Member.Id == _memberId);

        public string Message => TreatmentErrors.MemberAlreadyAdded;
    }

}
