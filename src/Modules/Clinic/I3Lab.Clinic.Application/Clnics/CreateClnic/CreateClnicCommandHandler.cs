using MediatR;
using FluentResults;
using I3Lab.Clinics.Domain.Clinics;

namespace I3Lab.Clinics.Application.Clnics.CreateClnic
{
    public class CreateClnicCommandHandler(
        IClinicRepository clinicRepository) : IRequestHandler<CreateClnicCommand, Result<ClnicDto>>
    {
        public async Task<Result<ClnicDto>> Handle(CreateClnicCommand request, CancellationToken cancellationToken)
        {
            var isClinicExist = await clinicRepository.ExistByName(ClinicName.Create(request.ClinicName));

            if (isClinicExist == true)
                return Result.Fail($"Clinic {request.ClinicName} already exist ");

            var clinic = Clinic.Create(
                ClinicName.Create(request.ClinicName),
                ClinicAddress.Create(request.ClinicAddress));

            await clinicRepository.AddAsync(clinic);

            await clinicRepository.SaveChangesAsync();

            return new ClnicDto();
        }
    }
}
