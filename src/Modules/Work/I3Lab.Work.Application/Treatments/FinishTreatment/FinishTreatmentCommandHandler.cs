using MediatR;
using FluentResults;
using I3Lab.Treatments.Domain.Treatments;

namespace I3Lab.Treatments.Application.Treatments.FinishTreatment
{
    public class FinishTreatmentCommandHandler(
        ITreatmentRepository treatmentRepository) : IRequestHandler<FinishTreatmentCommand, Result>
    {
        public async Task<Result> Handle(FinishTreatmentCommand request, CancellationToken cancellationToken)
        {
            var treatment = await treatmentRepository.GetByIdAsync(new TreatmentId(request.TreatmentId));

            treatment.Finish();

            await treatmentRepository.SaveChangesAsync(cancellationToken);

            return Result.Ok();
        }
    }
}
