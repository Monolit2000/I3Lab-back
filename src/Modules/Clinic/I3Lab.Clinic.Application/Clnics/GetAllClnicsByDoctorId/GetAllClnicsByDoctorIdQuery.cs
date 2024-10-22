
using FluentResults;
using I3Lab.Clinics.Application.Clnics.GetAllClnics;
using MediatR;

namespace I3Lab.Clinics.Application.Clnics.GetAllClnicsByDoctorId
{
    public class GetAllClnicsByDoctorIdQuery : IRequest<Result<List<ClinicDto>>>
    {
        public Guid DoctorId { get; set; }  
    }
}
