using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Domain.Members
{
    public class MemberRole : ValueObject
    {
        public string Value { get; }

        internal static MemberRole Doctor => new MemberRole(nameof(Doctor));
        internal static MemberRole Artisan => new MemberRole(nameof(Artisan));
        internal static MemberRole Admin => new MemberRole(nameof(Admin));

        internal static MemberRole Customer => new MemberRole(nameof(Customer));

        private MemberRole(string value)
        {
            Value = value;
        }

    }
}
