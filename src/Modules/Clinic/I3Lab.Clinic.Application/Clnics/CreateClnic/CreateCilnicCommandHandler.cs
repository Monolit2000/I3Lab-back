using MediatR;
using FluentResults;
using I3Lab.Clinics.Domain.Clinics;

namespace I3Lab.Clinics.Application.Clnics.CreateClnic
{
    public class CreateCilnicCommandHandler(
        IClinicRepository clinicRepository) : IRequestHandler<CreateClinicCommand, Result<ClinicDto>>
    {
        public async Task<Result<ClinicDto>> Handle(CreateClinicCommand request, CancellationToken cancellationToken)
        {
            var isClinicExist = await clinicRepository.ExistByName(ClinicName.Create(request.ClinicName));

            if (isClinicExist == true)
                return Result.Fail(ClinicApplicationError.ClinicAlreadyExist(request.ClinicName));

            var clinic = Clinic.Create(
                ClinicName.Create(request.ClinicName),
                ClinicAddress.Create(request.ClinicAddress));

            await clinicRepository.AddAsync(clinic);

            await clinicRepository.SaveChangesAsync();

            return new ClinicDto();
        }
    }
}
