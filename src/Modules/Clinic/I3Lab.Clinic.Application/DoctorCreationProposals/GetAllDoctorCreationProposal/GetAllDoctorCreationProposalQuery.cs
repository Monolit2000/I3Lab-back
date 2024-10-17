using FluentResults;
using MediatR;

namespace I3Lab.Doctors.Application.DoctorCreationProposals.GetAllDoctorCreationProposal
{
    public class GetAllDoctorCreationProposalQuery : IRequest<Result<List<DoctorCreationProposalDto>>>
    {
    }
}
