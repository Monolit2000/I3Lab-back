using FluentResults;
using MediatR;
using I3Lab.Clinics.Domain.DoctorCreationProposals;

namespace I3Lab.Doctors.Application.DoctorCreationProposals.RejectDoctorCreationProposal
{
    public class RejectDoctorCreationProposalCommandHandler(
        IDoctorCreationProposalRepository doctorCreationProposalRepository) : IRequestHandler<RejectDoctorCreationProposalCommand, Result>
    {
        public async Task<Result> Handle(RejectDoctorCreationProposalCommand request, CancellationToken cancellationToken)
        {
            var proposal = await doctorCreationProposalRepository.GetByIdAsync(new DoctorCreationProposalId(request.DoctorCreationProposalId));

            if (proposal == null)
                return Result.Fail("Proposal not exist");

            proposal.Reject();

            return Result.Ok();
        }
    }
}
