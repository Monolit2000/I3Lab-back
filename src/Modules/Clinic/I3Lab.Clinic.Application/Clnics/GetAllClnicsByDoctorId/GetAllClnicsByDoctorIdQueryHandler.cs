using FluentResults;
using I3Lab.Clinics.Application.Clnics.GetAllClnics;
using I3Lab.Clinics.Domain.Clinics;
using I3Lab.Clinics.Domain.Doctors;
using MediatR;

namespace I3Lab.Clinics.Application.Clnics.GetAllClnicsByDoctorId
{
    public class GetAllClnicsByDoctorIdQueryHandler(
        IClinicRepository clinicRepository) : IRequestHandler<GetAllClnicsByDoctorIdQuery, Result<List<ClinicDto>>>
    {
        public async Task<Result<List<ClinicDto>>> Handle(GetAllClnicsByDoctorIdQuery request, CancellationToken cancellationToken)
        {
            var clinics = await clinicRepository.GetAllClnicsByDoctorId(new DoctorId(request.DoctorId));

            if(clinics.Any() is false)
                return new List<ClinicDto>();

            return clinics.Select(x => new ClinicDto { Id = x.Id.Value }).ToList();
        }
    }
}





//var doctor = await doctorRepository.GetByIdAsync(new DoctorId(request.DoctorId));

//if (doctor == null)
//    return Result.Fail("ClinicErrors.DoctorNotFound");

//var clinics = await clinicRepository.GetAllClnicsByDoctorId(new DoctorId(request.DoctorId));

//var clinicDtoTasks = doctor.Clinics.Select(async x => {
//    var clinic = await clinicRepository.GetByIdAsync(x.ClinicId);
//    return new ClinicDto { Id = clinic.Id.Value};
//}).ToList();

//var clinicDtos = (await Task.WhenAll(clinicDtoTasks)).ToList();