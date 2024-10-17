using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Doctors.Application.DoctorCreationProposals.ConfirmDoctorCreationProposal
{
    public class ConfirmDoctorCreationProposalCommand : IRequest<Result<DoctorCreationProposalDto>>
    {
        public Guid DoctorCreationProposalId { get; set; }

        public ConfirmDoctorCreationProposalCommand(Guid doctorCreationProposalId)
        {
            DoctorCreationProposalId = doctorCreationProposalId;
        }

    }
}
