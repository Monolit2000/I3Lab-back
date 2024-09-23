using FluentResults;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments;
using MediatR;

namespace I3Lab.Treatments.Application.Treatments.RemoveMember
{
    public class RemoveTreatmentMemberCommandHandler(
        ITreatmentRepository tretmentRepository) : IRequestHandler<RemoveTreatmentMemberCommand, Result>
    {
        public async Task<Result> Handle(RemoveTreatmentMemberCommand request, CancellationToken cancellationToken)
        {
            var treatment = await tretmentRepository.GetByIdAsync(new TreatmentId(request.TreatmentId), cancellationToken);

            treatment.RemoveTreatmentMember(new MemberId(request.TreatmentMemberId), new MemberId(request.TreatmentRemovingMemberId));

            await tretmentRepository.SaveChangesAsync();

            return Result.Ok();
        }
    }
}
