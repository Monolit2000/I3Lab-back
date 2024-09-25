using FluentResults;
using I3Lab.Treatments.Domain.Treatments;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.Treatments.CancelTreatment
{
    public class CancelTreatmentCommandHandler(
        ITreatmentRepository treatmentRepository) : IRequestHandler<CancelTreatmentCommand, Result>
    {
        public async Task<Result> Handle(CancelTreatmentCommand request, CancellationToken cancellationToken)
        {
            var treatment = await treatmentRepository.GetByIdAsync(new TreatmentId(request.TreatmentId));
            treatment.Finish();

            await treatmentRepository.SaveChangesAsync(cancellationToken);

            return Result.Ok();
        }
    }
}
