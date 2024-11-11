using MediatR;
using FluentResults;
using I3Lab.Clinics.Domain.Clinics;
using I3Lab.Clinics.Domain.Doctors;
using MassTransit;

namespace I3Lab.Clinics.Application.Clnics.AddClinicDoctor
{
    public class AddClinicDoctorCommandHandler(
        IClinicRepository clinicRepository) : IRequestHandler<AddClinicDoctorCommand, Result>
    {
        public async Task<Result> Handle(AddClinicDoctorCommand request, CancellationToken cancellationToken)
        {
            var clinic = await clinicRepository.GetByIdAsync(new ClinicId(request.ClinicId));

            if (clinic is null)
                return Result.Fail(ClinicApplicationError.ClinicNotFound);

            var result = clinic.AddDoctor(new DoctorId(request.DoctorId));
            if (result.IsFailed)
                return result;

            await clinicRepository.SaveChangesAsync();

            return result;

        }
    }
}
