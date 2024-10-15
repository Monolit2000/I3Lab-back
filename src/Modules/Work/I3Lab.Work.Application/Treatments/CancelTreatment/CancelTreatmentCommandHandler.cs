using MediatR;
using FluentResults;
using I3Lab.Treatments.Domain.Treatments;

namespace I3Lab.Treatments.Application.Treatments.CancelTreatment
{
    public class CancelTreatmentCommandHandler(
        ITreatmentRepository treatmentRepository) : IRequestHandler<CancelTreatmentCommand, Result>
    {
        public async Task<Result> Handle(CancelTreatmentCommand request, CancellationToken cancellationToken)
        {
            var treatment = await treatmentRepository.GetByIdAsync(new TreatmentId(request.TreatmentId));

            treatment.Cancel();

            await treatmentRepository.SaveChangesAsync(cancellationToken);

            return Result.Ok();
        }
    }
}
