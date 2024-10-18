using MediatR;
using FluentResults;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Application.Configuration.Errors;
using I3Lab.Treatments.Application.Treatments.ApplicationErrors;
using I3Lab.Treatments.Application.Treatments.TreatmentErrors;

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
                return Result.Fail(TreatmentError.CreatorIsNull);

            var patient = await memberRepository.GetAsync(new MemberId(request.PatientId));
            if (patient is null)
                return Result.Fail(TreatmentError.PatientIsNull);

            var sdf = await AsyncCall(request);

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

        private async Task<Result<(Member, Member)>> AsyncCall(CreateTreatmentCommand request)
        {
            var (creatorTask, patientTask) = (
                memberRepository.GetAsync(new MemberId(request.CreatorId)),
                memberRepository.GetAsync(new MemberId(request.PatientId)));

            await Task.WhenAll(creatorTask, patientTask);

            var creator = await creatorTask;
            var patient = await patientTask;

            if (creator is null)
                return Result.Fail(TreatmentError.CreatorIsNull);

            if (patient is null)
                return Result.Fail(TreatmentError.PatientIsNull);

            return (creator, patient);
        }
    }
}
