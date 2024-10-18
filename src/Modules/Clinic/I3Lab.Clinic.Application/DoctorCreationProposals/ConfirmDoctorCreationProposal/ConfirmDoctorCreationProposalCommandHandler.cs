using MediatR;
using FluentResults;
using I3Lab.Clinics.Domain.DoctorCreationProposals;

namespace I3Lab.Doctors.Application.DoctorCreationProposals.ConfirmDoctorCreationProposal
{
    public class ConfirmDoctorCreationProposalCommandHandler(
        IDoctorCreationProposalRepository doctorCreationProposalRepository) : IRequestHandler<ConfirmDoctorCreationProposalCommand, Result<DoctorCreationProposalDto>>
    {
        public async Task<Result<DoctorCreationProposalDto>> Handle(ConfirmDoctorCreationProposalCommand request, CancellationToken cancellationToken)
        {
            var proposal = await doctorCreationProposalRepository.GetByIdAsync(new DoctorCreationProposalId(request.DoctorCreationProposalId));

            if (proposal == null)
                return Result.Fail("Proposal not exist");

            var result = proposal.Confirm();

            return result;
        }
    }
}
