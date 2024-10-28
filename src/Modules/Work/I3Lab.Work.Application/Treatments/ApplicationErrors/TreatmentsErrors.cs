using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.Treatments.ApplicationErrors
{
    public static class TreatmentsErrors
    {
        public static string NotUniqueName = "Treatments name is not unique";

        public static string MemberNotFound => "Member not found";

        public static string TreatmentNotFound = "Treatment not found";

        public static string CreatorIsNull => "Creator is null";
        public static string PatientIsNull => "Patient is null";
    }
}
