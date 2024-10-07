using MediatR;
using FluentResults;
using I3Lab.Clinics.Domain.Clinics;
using Microsoft.Extensions.Azure;

namespace I3Lab.Clinics.Application.Clnics.GetAllClnics
{
    public class GetAllClnicsQueryHandler(
        IClinicRepository clinicRepository) : IRequestHandler<GetAllClnicsQuery, Result<List<ClinicDto>>>
    {
        public async Task<Result<List<ClinicDto>>> Handle(GetAllClnicsQuery request, CancellationToken cancellationToken)
        {
            var clinics = await clinicRepository.GetAllAsync();

            if(clinics.Any() is false)
                return new List<ClinicDto>();   

            var clinicDtos = clinics.Select(clinic => new ClinicDto
            {
                Id = clinic.Id.Value,
                Name = clinic.ClinicName.Value,
                Address = clinic.Address.Value,
                Status = clinic.Status.Value,
                CreatedAt = clinic.CreatedAt
            }).ToList();

            return Result.Ok(clinicDtos);
        }
    }
}
