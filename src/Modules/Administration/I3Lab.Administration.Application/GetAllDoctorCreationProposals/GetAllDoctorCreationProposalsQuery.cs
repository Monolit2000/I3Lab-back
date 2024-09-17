using FluentResults;
using I3Lab.Administration.Application.GetAllDoctorCreationProposals;
using MediatR;

namespace I3Lab.Administration.Application.GetDoctorCreationProposals
{
    public class GetAllDoctorCreationProposalsQuery : IRequest<Result<List<DoctorCreationProposDto>>>
    {


    }
}
