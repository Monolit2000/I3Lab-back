using MediatR;
using FluentResults;
using I3Lab.Clinics.Domain.DoctorCreationProposals;

namespace I3Lab.Doctors.Application.DoctorCreationProposals.ConfirmDoctorCreationProposal
{
    public class ConfirmDoctorCreationProposalCommandHandler(
        IDoctorCreationProposalRepository doctorCreationProposalRepository) 
        : IRequestHandler<ConfirmDoctorCreationProposalCommand, Result>
    {
        public async Task<Result> Handle(ConfirmDoctorCreationProposalCommand request, CancellationToken cancellationToken)
        {
            var proposal = await doctorCreationProposalRepository.GetByIdAsync(new DoctorCreationProposalId(request.DoctorCreationProposalId), cancellationToken);

            if (proposal == null)
                return Result.Fail("Proposal not exist");

            var result = proposal.Confirm();

            await doctorCreationProposalRepository.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
