using MassTransit.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Doctors.Application.DoctorCreationProposals.CreateDoctorCreationProposal
{
    public class DoctorCreationProposalDto
    {
        public Guid ProposalId { get; }

        public DoctorCreationProposalDto(Guid proposalId)
        {
            ProposalId = proposalId;
        }
    }
}
