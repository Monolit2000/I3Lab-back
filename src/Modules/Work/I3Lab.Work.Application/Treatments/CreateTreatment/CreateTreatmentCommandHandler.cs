using MediatR;
using FluentResults;
using I3Lab.Works.Domain.Treatments;
using I3Lab.Works.Domain.Members;
using I3Lab.Works.Application.Treatments.ApplicationErrors;


namespace I3Lab.Works.Application.Treatments.CreateTreatment
{
    public class CreateTreatmentCommandHandler(
        ITretmentRepository tretmentRepository,
        IMemberRepository memberRepository) : IRequestHandler<CreateTreatmentCommand, Result<TreatmentDto>>
    {
        public async Task<Result<TreatmentDto>> Handle(CreateTreatmentCommand request, CancellationToken cancellationToken)
        {
            if (!await tretmentRepository.IsNameUniqueAsync(request.TreatmentTitel))
                return Result.Fail(TreatmentsErrors.NotUniqueName);

            var creator = await memberRepository.GetMemberByIdAsync(new MemberId(request.CreatorId));
            if (creator is null)
                return Result.Fail("Creator is null");

            var patient = await memberRepository.GetMemberByIdAsync(new MemberId(request.PatientId));
            if (creator is null)
                return Result.Fail("patient is null");

            var titel = Titel.Create(request.TreatmentTitel);

            var treatment = Treatment.CreateNew(
                creator, 
                patient, 
                titel);

            await tretmentRepository.AddAsync(treatment);

            await tretmentRepository.SaveChangesAsync();

            var treatmentDto = new TreatmentDto();

            return treatmentDto;
        }
    }
}
