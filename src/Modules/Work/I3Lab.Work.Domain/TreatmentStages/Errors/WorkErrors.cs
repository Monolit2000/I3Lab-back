using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace I3Lab.Treatments.Domain.TreatmentStages.Errors
{
    public static class WorkErrors
    {
        public static string WorkMemberNotFoundError()
            => "The member adding the new work member is not present in the work TreatmentMembers list";

        public static string MemberNotHaveRequiredRole() 
            => "The member does not have the required role";

    }
}
