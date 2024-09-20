using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Doctors.Application.DoctorCreationProposals.RejectDoctorCreationProposal
{
    public class RejectDoctorCreationProposalCommand : IRequest<Result>
    {
        public Guid DoctorCreationProposalId {  get; set; }

        public RejectDoctorCreationProposalCommand()
        {
                
        }

        public RejectDoctorCreationProposalCommand(Guid doctorCreationProposalId)
        {
            DoctorCreationProposalId = doctorCreationProposalId;
        }
    }
}
