//using FluentResults;
//using I3Lab.Doctors.Domain.DoctorCreationProposals;
//using MediatR;


//namespace I3Lab.Doctors.Application.DoctorCreationProposals.ConfirmDoctorCreationProposal
//{
//    public class ConfirmDoctorCreationProposalCommandHandler(
//        IDoctorCreationProposalRepository doctorCreationProposalRepository) : IRequestHandler<ConfirmDoctorCreationProposalCommand, Result<DoctorCreationProposalDto>>
//    {
//        public async Task<Result<DoctorCreationProposalDto>> Handle(ConfirmDoctorCreationProposalCommand request, CancellationToken cancellationToken)
//        {
//            var proposal = await doctorCreationProposalRepository.GetByIdAsync(new DoctorCreationProposalId(request.DoctorCreationProposalId));

//            if (proposal == null)
//                return Result.Fail("Proposal not exist");

//            proposal.Confirm();

//            return Result.Ok();
//        }
//    }
//}
