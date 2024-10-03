using MediatR;
using FluentResults;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Application.Treatments.ApplicationErrors;


namespace I3Lab.Treatments.Application.Treatments.CreateTreatment
{
    public class CreateTreatmentCommandHandler(
        ITreatmentRepository tretmentRepository,
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

            var treatment = Treatment.CreateNew(
                creator, 
                patient,
                TreatmentTitel.Create(request.TreatmentTitel));

            await tretmentRepository.AddAsync(treatment);

            await tretmentRepository.SaveChangesAsync();

            var treatmentDto = new TreatmentDto()
            {
                Id = treatment.Id.Value,
                IvniteToken = treatment.GetInvitationToken()
            };

            return treatmentDto;
        }
    }
}
