using I3Lab.Treatments.Application.Configuration.Commands;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.TreatmentStageChats;
using I3Lab.Treatments.Domain.TreatmentStages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.TreatmentStageChats.AddChatMemberToAllTreatmentStageChatsByTreatmentId
{
    public class AddChatMemberToAllTreatmentStageChatsByTreatmentIdCommandHandler(
        IMemberRepository memberRepository,
        ITreatmentStageRepository treatmentStageRepository,
        ITreatmentStageChatRepository treatmentStageChatRepository) : ICommandHandler<AddChatMemberToAllTreatmentStageChatsByTreatmentIdCommand>
    {
        public async Task Handle(AddChatMemberToAllTreatmentStageChatsByTreatmentIdCommand request, CancellationToken cancellationToken)
        {
            var treatmentStages = await treatmentStageRepository.GetAllByTreatmentIdAsync(request.TreatmentId);

            if (treatmentStages.Any() is false)
                return;

            var member = await memberRepository.GetMemberByIdAsync(request.MemberId);

            var tasks = treatmentStages.Select(async treatmentStage =>
            {
                var treatmentStageChat = await treatmentStageChatRepository.GetByTreatmentStageIdAsync(treatmentStage.Id, cancellationToken);
                treatmentStageChat?.AddChatMember(member);
                await treatmentStageRepository.SaveChangesAsync(cancellationToken);

            }).ToList();

            await Task.WhenAll(tasks);
        }
    }
}
