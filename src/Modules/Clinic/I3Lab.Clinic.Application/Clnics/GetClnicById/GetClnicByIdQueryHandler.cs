using FluentResults;
using I3Lab.Clinics.Domain.Clinics;
using I3Lab.Clinics.Domain.Clinics;
using MediatR;

namespace I3Lab.Clinics.Application.Clnics.GetClnicById
{
    internal class GetClnicByIdQueryHandler(
        IClinicRepository clinicRepository) : IRequestHandler<GetClnicByIdQuery, Result<ClinicDto>>
    {
        public async Task<Result<ClinicDto>> Handle(GetClnicByIdQuery request, CancellationToken cancellationToken)
        {
            var clinic = await clinicRepository.GetByIdAsync(new ClinicId(request.ClinicId));

            if (clinic is null)
                return Result.Fail("Clinic not found");

            var clinicDto = new ClinicDto
            {
                Id = clinic.Id.Value,
                Name = clinic.ClinicName.Value,
                Address = clinic.Address.Value,
                Status = clinic.Status.Value,
                CreatedAt = clinic.CreatedAt
            };

            return clinicDto;
        }
    }
}
