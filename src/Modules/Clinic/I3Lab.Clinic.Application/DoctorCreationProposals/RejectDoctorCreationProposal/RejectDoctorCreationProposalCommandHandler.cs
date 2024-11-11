using FluentResults;
using MediatR;
using I3Lab.Clinics.Domain.DoctorCreationProposals;

namespace I3Lab.Clinics.Application.DoctorCreationProposals.RejectDoctorCreationProposal
{
    public class RejectDoctorCreationProposalCommandHandler(
        IDoctorCreationProposalRepository doctorCreationProposalRepository) : IRequestHandler<RejectDoctorCreationProposalCommand, Result>
    {
        public async Task<Result> Handle(RejectDoctorCreationProposalCommand request, CancellationToken cancellationToken)
        {
            var proposal = await doctorCreationProposalRepository
                .GetByIdAsync(new DoctorCreationProposalId(request.DoctorCreationProposalId), cancellationToken);

            if (proposal == null)
                return Result.Fail(DoctorCreationProposalApplicationErrors.ProposalNotExist);

            var result =  proposal.Reject();

            await doctorCreationProposalRepository.SaveChangesAsync(cancellationToken); 

            return result;
        }
    }
}
