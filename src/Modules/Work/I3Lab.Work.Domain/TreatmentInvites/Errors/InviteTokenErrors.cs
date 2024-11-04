using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Domain.TreatmentInvites.Errors
{
    public class InviteTokenErrors
    {
        public static string InvalidToken => "Invalid token";
        public static string ExpiredToken => "Token has expired";
    }
}
