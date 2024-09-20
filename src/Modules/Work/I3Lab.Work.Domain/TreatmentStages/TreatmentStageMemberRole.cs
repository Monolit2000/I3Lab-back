using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Domain.TreatmentStages
{
    public class TreatmentStageMemberRole : ValueObject
    {
        public string Value { get; }

        internal static TreatmentStageMemberRole Customer => new TreatmentStageMemberRole(nameof(Customer));
        internal static TreatmentStageMemberRole Doctor => new TreatmentStageMemberRole(nameof(Doctor));
        internal static TreatmentStageMemberRole Moderator => new TreatmentStageMemberRole(nameof(Moderator));
        internal static TreatmentStageMemberRole Admin => new TreatmentStageMemberRole(nameof(Admin));

        private TreatmentStageMemberRole(string value)
        {
            Value = value;
        }
    }
}
