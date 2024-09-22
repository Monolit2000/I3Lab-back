using FluentResults;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.TreatmentStageChats;
using I3Lab.Treatments.Domain.TreatmentStages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.TreatmentStageChats.RemoveChatMember
{
    public class RemoveChatMemberCommandHandler(
        ITreatmentStageChatRepository treatmentStageChatRepository) : IRequestHandler<RemoveChatMemberCommand>
    {
        public async Task Handle(RemoveChatMemberCommand request, CancellationToken cancellationToken)
        {
            var treatmentStageChat = await treatmentStageChatRepository.GetByTreatmentStageIdAsync(new TreatmentStageId(request.WorkId));

            treatmentStageChat.RemoveChatMember(new MemberId(request.MemberId));

            await treatmentStageChatRepository.SaveChangesAsync();
        }
    }
}
