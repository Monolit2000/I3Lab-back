using MediatR;
using FluentResults;
using I3Lab.Works.Domain.Works;
using I3Lab.Works.Domain.Treatment;
using I3Lab.Works.Domain.Members;
using I3Lab.BuildingBlocks.Application.BlobStorage;
using System.Xml.Linq;
using I3Lab.Works.Application.Treatments.ApplicationErrors;


namespace I3Lab.Works.Application.Treatments.CreateTreatment
{
    public class CreateTreatmentCommandHandler(
        ITretmentRepository tretmentRepository) : IRequestHandler<CreateTreatmentCommand, Result<TreatmentDto>>
    {
        public async Task<Result<TreatmentDto>> Handle(CreateTreatmentCommand request, CancellationToken cancellationToken)
        {
            if (!await tretmentRepository.IsNameUniqueAsync(request.TreatmentName))
                return Result.Fail(TreatmentsErrors.NotUniqueName);

            if (string.IsNullOrEmpty(request.TreatmentName))
                return Result.Fail("Treatment name is Empty");

            var treatment = Treatment.CreateNew(
                new MemberId(request.CreatorId),
                new MemberId(request.PatientId),
                request.TreatmentName);

            await tretmentRepository.AddAsync(treatment);

            await tretmentRepository.SaveChangesAsync();

            var treatmentDto = new TreatmentDto();

            return treatmentDto;
        }
    }
}
