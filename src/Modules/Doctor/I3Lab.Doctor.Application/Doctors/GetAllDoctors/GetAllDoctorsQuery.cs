using FluentResults;
using MediatR;

namespace I3Lab.Doctors.Application.Doctors.GetOllDoctors
{
    public class GetAllDoctorsQuery : IRequest<Result<List<DoctorDto>>>
    {

    }
}
