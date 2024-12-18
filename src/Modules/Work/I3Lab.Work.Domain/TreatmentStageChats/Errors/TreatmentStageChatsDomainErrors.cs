﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Domain.TreatmentStageChats.Errors
{
    public class TreatmentStageChatsDomainErrors
    {
        public static string SenderNotInChat => "Sender not in chat";
        public static string MemberNotInChat => "Member not in chat";
        public static string MemberMustBeMessageOwner => "Member must be message owner";
    }
}
