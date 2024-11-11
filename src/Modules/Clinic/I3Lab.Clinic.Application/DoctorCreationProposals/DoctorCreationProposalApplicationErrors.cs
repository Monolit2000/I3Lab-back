using Quartz.Impl.AdoJobStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Clinics.Application.DoctorCreationProposals
{
    public static class DoctorCreationProposalApplicationErrors
    {
        public static string ProposalAlreadyExist(string email) 
            => $"Proposal with this email '{email}' already isExist";
        public static string ProposalNotExist => "Proposal not exist";

    }
}
