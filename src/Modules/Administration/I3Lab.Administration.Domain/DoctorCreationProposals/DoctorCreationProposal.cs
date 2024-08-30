using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Administration.Domain.DoctorCreationProposals
{
    public class DoctorCreationProposal
    {
        public DoctorCreationProposalId Id { get; }

        public DoctorName Name { get; private set; }

        public Email Email { get; private set; }

        public PhoneNumber PhoneNumber { get; private set; }
         
        public DoctorCreationProposalStatus ConfirmationStatus { get; private set; }

        public DoctorAvatar? DoctorAvatar { get; private set; }

        public DateTime CreatedAt { get; }

    }
}
