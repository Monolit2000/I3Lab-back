using FluentResults;
using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.Treatments;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.Treatments.AddTreatmentMember
{
    public class AddTreatmentMemberCommandHandler(
        IMemberRepository memberRepository,
        ITretmentRepository tretmentRepository) : IRequestHandler<AddTreatmentMemberCommand>
    {
        public async Task Handle(AddTreatmentMemberCommand request, CancellationToken cancellationToken)
        {
            var treatment = await tretmentRepository.GetByIdAsync(new TreatmentId(request.TreatmentId), cancellationToken);

            var member = await memberRepository.GetMemberByIdAsync(new MemberId(request.MemberId));

            var invaiter = await memberRepository.GetMemberByIdAsync(new MemberId(request.InvaiterId));

            var result = treatment.AddTreatmentMember(member, invaiter);

            if (result.IsFailed)
                return;

            await tretmentRepository.SaveChangesAsync();
        }
    }
}
