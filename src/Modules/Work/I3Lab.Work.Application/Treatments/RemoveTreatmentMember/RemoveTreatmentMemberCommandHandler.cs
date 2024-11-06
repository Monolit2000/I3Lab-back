using MediatR;
using FluentResults;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Application.Treatments.ApplicationErrors;

namespace I3Lab.Treatments.Application.Treatments.RemoveTreatmentMember
{
    public class RemoveTreatmentMemberCommandHandler(
        ITreatmentRepository tretmentRepository) : IRequestHandler<RemoveTreatmentMemberCommand, Result>
    {
        public async Task<Result> Handle(RemoveTreatmentMemberCommand request, CancellationToken cancellationToken)
        {
            var treatment = await tretmentRepository.GetByIdAsync(new TreatmentId(request.TreatmentId), cancellationToken);
            if (treatment == null)
                return Result.Fail(TreatmentsErrors.TreatmentNotFound);

            var result = treatment.RemoveTreatmentMember(
                new MemberId(request.TreatmentMemberId), 
                new MemberId(request.TreatmentRemovingMemberId));

            if (result.IsFailed)
                return result;

            await tretmentRepository.SaveChangesAsync();

            return Result.Ok();
        }
    }
}
