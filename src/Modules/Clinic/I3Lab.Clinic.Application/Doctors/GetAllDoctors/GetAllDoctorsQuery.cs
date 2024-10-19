using FluentResults;
using MediatR;

namespace I3Lab.Clinics.Application.Doctors.GetOllDoctors
{
    public class GetAllDoctorsQuery : IRequest<Result<List<DoctorDto>>>
    {

    }
}
