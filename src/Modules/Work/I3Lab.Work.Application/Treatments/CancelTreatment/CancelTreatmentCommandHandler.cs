using MediatR;
using FluentResults;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Application.Treatments.ApplicationErrors;

namespace I3Lab.Treatments.Application.Treatments.CancelTreatment
{
    public class CancelTreatmentCommandHandler(
        ITreatmentRepository treatmentRepository) : IRequestHandler<CancelTreatmentCommand, Result>
    {
        public async Task<Result> Handle(CancelTreatmentCommand request, CancellationToken cancellationToken)
        {
            var treatment = await treatmentRepository.GetByIdAsync(new TreatmentId(request.TreatmentId));
            if (treatment is null)
                return Result.Fail(TreatmentsErrors.TreatmentNotFound);

            var result = treatment.Cancel();
            if (result.IsFailed)
                return result;

            await treatmentRepository.SaveChangesAsync(cancellationToken);

            return Result.Ok();
        }
    }
}
