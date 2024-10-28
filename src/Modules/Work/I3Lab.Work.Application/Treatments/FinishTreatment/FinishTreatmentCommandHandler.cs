using MediatR;
using FluentResults;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Application.Treatments.ApplicationErrors;


namespace I3Lab.Treatments.Application.Treatments.FinishTreatment
{
    public class FinishTreatmentCommandHandler(
        ITreatmentRepository treatmentRepository) : IRequestHandler<FinishTreatmentCommand, Result>
    {
        public async Task<Result> Handle(FinishTreatmentCommand request, CancellationToken cancellationToken)
        {
            var treatment = await treatmentRepository.GetByIdAsync(new TreatmentId(request.TreatmentId));

            if (treatment is null)
                return Result.Fail(TreatmentsErrors.TreatmentNotFound);

            var result = treatment.Finish();
            if (result.IsFailed)
                return result;

            await treatmentRepository.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
