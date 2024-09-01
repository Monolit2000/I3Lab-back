using FluentResults;
using I3Lab.Administration.Domain.DoctorCreationProposals;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Administration.Application.ConfirmDoctorCreationPropos
{
    public class ConfirmDoctorCreationProposalCommandHandler(
        IDoctorCreationProposalRepository doctorCreationProposalRepository) : IRequestHandler<ConfirmDoctorCreationProposCommand, Result<DoctorCreationProposDto>>
    {
        public async Task<Result<DoctorCreationProposDto>> Handle(ConfirmDoctorCreationProposCommand request, CancellationToken cancellationToken)
        {
            var doctorCreationProposal = await doctorCreationProposalRepository.GetByIdAsync(
                new DoctorCreationProposalId(request.DoctorCreationProposalId));

            doctorCreationProposal.Confirm();

            return new DoctorCreationProposDto();
        }
    }
}
