using FluentResults;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments;
using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.Treatments.AddTreatmentMember
{
    public class AddTreatmentMemberCommandHandler(
        IMemberRepository memberRepository,
        ITreatmentRepository treatmentRepository) : IRequestHandler<AddTreatmentMemberCommand, Result>
    {
        public async Task<Result> Handle(AddTreatmentMemberCommand request, CancellationToken cancellationToken)
        {
            var treatment = await treatmentRepository.GetByIdAsync(new TreatmentId(request.TreatmentId), cancellationToken);

            var member = await memberRepository.GetAsync(new MemberId(request.MemberId));

            var result = treatment.AddToTreatmentMembers(member);
            if (result.IsFailed)
                return result; 

            await treatmentRepository.SaveChangesAsync();

            return result;
        }
    }
}
