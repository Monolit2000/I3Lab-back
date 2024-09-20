using FluentResults;
using I3Lab.Treatments.Domain.TreatmentInvites;
using I3Lab.Treatments.Domain.Treatments;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.TreatmentInvites.GetAllTreatmentInvitesByTreatmentId
{
    public class GetAllTreatmentInvitesByTreatmentIdQueryHandler(
        ITreatmentInviteRepository treatmentInviteRepository) : IRequestHandler<GetAllTreatmentInvitesByTreatmentIdQuery, Result<List<TreatmentInviteDto>>>
    {
        public async Task<Result<List<TreatmentInviteDto>>> Handle(GetAllTreatmentInvitesByTreatmentIdQuery request, CancellationToken cancellationToken)
        {
            var treatmentInvites = await treatmentInviteRepository.GetAllByTreatmentIdAsync(new TreatmentId(request.TreatmentId));

            var treatmentInviteDtos = treatmentInvites.Select(invite => new TreatmentInviteDto
            {
                Id = invite.Id.Value,
                MemberToInviteEmail = invite.MemberToInvite.Email, 
                InviterEmail = invite.Inviter.Email, 
                Status = invite.TreatmentInviteStatus.Value,
                OcurredOn = invite.OcurredOn
            }).ToList();

            return Result.Ok(treatmentInviteDtos);
        }
    }
}
