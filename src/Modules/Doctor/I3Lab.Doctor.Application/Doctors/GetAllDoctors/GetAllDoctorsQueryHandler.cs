using FluentResults;
using I3Lab.Doctors.Domain.Doctors;
using MediatR;

namespace I3Lab.Doctors.Application.Doctors.GetOllDoctors
{
    public class GetAllDoctorsQueryHandler(
        IDoctorRepository doctorRepository) : IRequestHandler<GetAllDoctorsQuery, Result<List<DoctorDto>>>
    {
        public async Task<Result<List<DoctorDto>>> Handle(GetAllDoctorsQuery request, CancellationToken cancellationToken)
        {
            var doctors = await doctorRepository.GetAll();

            var doctorDtos = doctors
                .Select(d => new DoctorDto(d))
                .ToList();

            return doctorDtos;
        }
    }
}
