using MediatR;
using FluentResults;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Application.Configuration.Errors;
using I3Lab.Treatments.Application.Treatments.ApplicationErrors;

namespace I3Lab.Treatments.Application.Treatments.CreateTreatment
{
    public class CreateTreatmentCommandHandler(
        IMemberRepository memberRepository, 
        ITreatmentRepository tretmentRepository) : IRequestHandler<CreateTreatmentCommand, Result<TreatmentDto>>
    {
        public async Task<Result<TreatmentDto>> Handle(CreateTreatmentCommand request, CancellationToken cancellationToken)
        {
            if (!await tretmentRepository.IsNameUniqueAsync(request.TreatmentTitel))
                return Result.Fail(StatusCodeErrors.NotUnique(TreatmentsErrors.NotUniqueName));

            var creator = await memberRepository.GetAsync(new MemberId(request.CreatorId));
            if (creator is null)
                return Result.Fail(TreatmentsErrors.CreatorIsNull);

            var patient = await memberRepository.GetAsync(new MemberId(request.PatientId));
            if (patient is null)
                return Result.Fail(TreatmentsErrors.PatientIsNull);

            var treatment = Treatment.CreateNew(
                creator, 
                patient,
                TreatmentTitel.Create(request.TreatmentTitel));

            await tretmentRepository.AddAsync(treatment);

            await tretmentRepository.SaveChangesAsync();

            var treatmentDto = new TreatmentDto()
            {
                Id = treatment.Id.Value,
                InviteToken = treatment.GetInvitationToken()
            };

            return treatmentDto;
        }
    }
}
