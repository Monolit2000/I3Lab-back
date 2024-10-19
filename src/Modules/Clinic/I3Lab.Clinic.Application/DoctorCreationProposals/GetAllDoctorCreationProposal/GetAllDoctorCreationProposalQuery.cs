using FluentResults;
using MediatR;

namespace I3Lab.Clinics.Application.DoctorCreationProposals.GetAllDoctorCreationProposal
{
    public class GetAllDoctorCreationProposalQuery : IRequest<Result<List<DoctorCreationProposalDto>>>
    {
    }
}
