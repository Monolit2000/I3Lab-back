using MediatR;
using FluentResults;

namespace I3Lab.Clinics.Application.Clnics.GetAllClnics
{
    public class GetAllClnicsQuery : IRequest<Result<List<ClinicDto>>>
    {
    }
}
