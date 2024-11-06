using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Domain.Treatments.Errors
{
    public static class TreatmentErrors
    {
        public static string MemberNotFound = "Member not found in treatment";
        
        public static string TreatmentNotFound = "Treatment not found";


        public static string MemberAlreadyAdded = "Member is already in treatment";

        public static string InvalidInviteLink = "Invalid invite link";

        public static string TreatmentAlreadyCanceled = "Treatment is already canceled";
    }
}
