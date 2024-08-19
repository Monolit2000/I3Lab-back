using MediatR;
using FluentResults;
using I3Lab.Works.Domain.Works;
using I3Lab.Works.Domain.Treatment;
using I3Lab.Works.Domain.Members;
using I3Lab.BuildingBlocks.Application.BlobStorage;


namespace I3Lab.Works.Application.Treatments.CreateTreatment
{
    public class CreateTreatmentCommandHandler(
        ITretmentRepository tretmentRepository,        
        IMemberContext memberContext) : IRequestHandler<CreateTreatmentCommand, Result<TreatmentDto>>
    {
        public async Task<Result<TreatmentDto>> Handle(CreateTreatmentCommand request, CancellationToken cancellationToken)
        {
            var treatment = Treatment.CreateNew(
                memberContext.MemberId,
                new MemberId(request.PatientId),
                request.TreatmentName);

            await tretmentRepository.AddAsync(treatment);

            await tretmentRepository.SaveChangesAsync();

            var treatmentDto = new TreatmentDto();

            return treatmentDto;
        }
    }
}
