using MediatR;
using FluentResults;
using I3Lab.Clinics.Domain.Doctors;

namespace I3Lab.Clinics.Application.Doctors.GetOllDoctors
{
    public class GetAllDoctorsQueryHandler(
        IDoctorRepository doctorRepository) : IRequestHandler<GetAllDoctorsQuery, Result<List<DoctorDto>>>
    {
        public async Task<Result<List<DoctorDto>>> Handle(GetAllDoctorsQuery request, CancellationToken cancellationToken)
        {
            var doctors = await doctorRepository.GetAllAsync();

            var doctorDtos = doctors
                .Select(d => new DoctorDto(d))
                .ToList();

            return doctorDtos;
        }
    }
}
