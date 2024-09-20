using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Domain.TreatmentStages.Rule
{
    public class OnlyExistingWorkMembersCanAddCustomerRule : IBusinessRule
    {
        private readonly IEnumerable<TreatmentStageMember> _workMembers;
        private readonly MemberId _addedBy;

        public OnlyExistingWorkMembersCanAddCustomerRule(IEnumerable<TreatmentStageMember> workMembers, MemberId addedBy)
        {
            _workMembers = workMembers;
            _addedBy = addedBy;
        }

        public bool IsBroken() => !_workMembers.Any(m => m.Member.Id == _addedBy);

        public string Message => "Only existing work TreatmentMembers can add a customer.";
    }
}
