
namespace I3Lab.Doctors.Application.DoctorCreationProposals.CreateDoctorCreationProposal
{
    public class DoctorCreationProposalDto
    {
        public Guid ProposalId { get; }

        public DoctorCreationProposalDto(Guid proposalId)
        {
            ProposalId = proposalId;
        }
    }
}
