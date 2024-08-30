using FluentResults;
using I3Lab.Administration.Domain.DoctorCreationProposals;
using MediatR;

namespace I3Lab.Administration.Application.RequestDoctorCreationProposalVerification
{
    public class RequestDoctorCreationProposalVerificationCommandHandler(
        IDoctorCreationProposals doctorCreationProposals) : IRequestHandler<RequestDoctorCreationProposalVerificationCommand, Result>
    {
        public Task<Result> Handle(RequestDoctorCreationProposalVerificationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
