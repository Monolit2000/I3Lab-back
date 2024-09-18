using FluentResults;
using MediatR;

namespace I3Lab.Administration.Application.ConfirmDoctorCreationPropos
{
    public class ConfirmDoctorCreationProposCommand : IRequest<Result<DoctorCreationProposDto>>
    {
        public Guid DoctorCreationProposalId { get; }

        public ConfirmDoctorCreationProposCommand(Guid doctorCreationProposalId)
        {
            DoctorCreationProposalId = doctorCreationProposalId;
        }
    }
}
