using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Domain.Works.Rule
{
    public class OnlyExistingWorkMembersCanAddCustomerRule : IBusinessRule
    {
        private readonly IEnumerable<WorkMember> _workMembers;
        private readonly MemberId _addedBy;

        public OnlyExistingWorkMembersCanAddCustomerRule(IEnumerable<WorkMember> workMembers, MemberId addedBy)
        {
            _workMembers = workMembers;
            _addedBy = addedBy;
        }

        public bool IsBroken() => !_workMembers.Any(m => m.Member.Id == _addedBy);

        public string Message => "Only existing work TreatmentMembers can add a customer.";
    }
}
