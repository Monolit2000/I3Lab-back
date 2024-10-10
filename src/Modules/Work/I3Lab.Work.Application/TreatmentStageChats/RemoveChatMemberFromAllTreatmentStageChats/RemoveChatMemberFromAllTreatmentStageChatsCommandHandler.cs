using I3Lab.Treatments.Domain.TreatmentStageChats;
using I3Lab.Treatments.Domain.TreatmentStages;
using MediatR;

namespace I3Lab.Treatments.Application.TreatmentStageChats.RemoveChatMemberWithAllChats
{
    public class RemoveChatMemberFromAllTreatmentStageChatsCommandHandler(
        ITreatmentStageRepository treatmentStageRepository,
        ITreatmentStageChatRepository treatmentStageChatRepository) : IRequestHandler<RemoveChatMemberFromAllTreatmentStageChatsCommand>
    {
        public async Task Handle(RemoveChatMemberFromAllTreatmentStageChatsCommand request, CancellationToken cancellationToken)
        {
            var treatmentStages = await treatmentStageRepository.GetAllByTreatmentIdAsync(request.TreatmentId);

            if (treatmentStages.Any() is false)
                return;

            var tasks = treatmentStages.Select(async treatmentStage =>
            {
                var treatmentStageChat = await treatmentStageChatRepository.GetByTreatmentStageIdAsync(treatmentStage.Id, cancellationToken);
                treatmentStageChat?.RemoveChatMember(request.MemberId);
                await treatmentStageRepository.SaveChangesAsync(cancellationToken);

            }).ToList();

            await Task.WhenAll(tasks);
        }
    }
}

//await Parallel.ForEachAsync(treatmentStages, async(treatmentStage, cancellationToken) =>
//{
//    var treatmentStageChat = await treatmentStageChatRepository.GetByTreatmentStageIdAsync(treatmentStage.Id, cancellationToken);

//    treatmentStageChat.RemoveChatMember(request.SenderId);
//});