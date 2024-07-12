using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Domain.Works
{
    public class WorkMemberRole : ValueObject
    {
        public string Value { get; }

        internal static WorkMemberRole Customer => new WorkMemberRole(nameof(Customer));
        internal static WorkMemberRole Doctor => new WorkMemberRole(nameof(Doctor));
        internal static WorkMemberRole Moderator => new WorkMemberRole(nameof(Moderator));
        internal static WorkMemberRole Admin => new WorkMemberRole(nameof(Admin));

        private WorkMemberRole(string value)
        {
            Value = value;
        }
    }
}
