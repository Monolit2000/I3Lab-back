using MediatR;
using FluentResults;
using I3Lab.Clinics.Domain.Clinics;
using I3Lab.Clinics.Domain.Doctors;

namespace I3Lab.Clinics.Application.Doctors.GetAllDoctorsByClinicId
{
    public class GetAllDoctorsByClinicIdQueryHandler(
        IClinicRepository clinicRepository,
        IDoctorRepository doctorRepository) : IRequestHandler<GetAllDoctorsByClinicIdQuery, Result<List<DoctorDto>>>
    {
        public async Task<Result<List<DoctorDto>>> Handle(GetAllDoctorsByClinicIdQuery request, CancellationToken cancellationToken)
        {
            var clinic = await clinicRepository.GetByIdAsync(new ClinicId(request.ClinicId));

            if (clinic == null)
                return Result.Fail(DoctorApplicationErrors.ClinicNotFaund);

            var doctorsDtoTasks = clinic.Doctors.Select(async x => 
            {
                var doctor = await doctorRepository.GetByIdAsync(x.DoctorId);
                return new DoctorDto(doctor);

            }).ToList();

            var doctorsDto = (await Task.WhenAll(doctorsDtoTasks)).ToList();

            return doctorsDto;
        }
    }
}
