using FluentResults;
using I3Lab.Clinics.Domain.Clinics;
using I3Lab.Clinics.Domain.Clnics;
using MediatR;
using System.Drawing.Drawing2D;

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
                ClinicName.Create(request.ClinicAddress),
                ClinicAddress.Create(request.ClinicAddress));

            await clinicRepository.AddAsync(clinic);

            return new ClnicDto();
        }
    }
}
