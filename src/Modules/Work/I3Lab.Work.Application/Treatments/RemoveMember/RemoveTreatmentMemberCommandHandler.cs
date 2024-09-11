using FluentResults;
using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.Treatments;
using MediatR;

namespace I3Lab.Works.Application.Treatments.RemoveMember
{
    public class RemoveTreatmentMemberCommandHandler(
        ITretmentRepository tretmentRepository) : IRequestHandler<RemoveTreatmentMemberCommand, Result>
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
