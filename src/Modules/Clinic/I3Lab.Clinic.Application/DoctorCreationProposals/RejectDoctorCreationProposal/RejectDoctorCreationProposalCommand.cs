using FluentResults;
using MediatR;

namespace I3Lab.Clinics.Application.DoctorCreationProposals.RejectDoctorCreationProposal
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
