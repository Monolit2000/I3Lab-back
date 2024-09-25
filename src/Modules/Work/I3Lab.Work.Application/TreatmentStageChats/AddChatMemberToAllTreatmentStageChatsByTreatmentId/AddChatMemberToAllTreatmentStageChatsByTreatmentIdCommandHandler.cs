using I3Lab.Treatments.Application.Configuration.Commands;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.TreatmentStageChats;
using I3Lab.Treatments.Domain.TreatmentStages;

namespace I3Lab.Treatments.Application.TreatmentStageChats.AddChatMemberToAllTreatmentStageChatsByTreatmentId
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

            if (member is null)
                return;

            var treatmentStageChats = await treatmentStageChatRepository.GetAllByTreatmentIdAsync(request.TreatmentId);

            var tasks = treatmentStageChats.Select(async treatmentStageChat =>
            {
                treatmentStageChat?.AddChatMember(member);
                await treatmentStageRepository.SaveChangesAsync(cancellationToken);
            });

            await Task.WhenAll(tasks);
        }
    }
}


            //var tasks = treatmentStages.Select(async treatmentStage =>
            //{
            //    var treatmentStageChat = await treatmentStageChatRepository.GetByTreatmentStageIdAsync(treatmentStage.Id, cancellationToken);
            //    treatmentStageChat?.AddChatMember(member);
            //    await treatmentStageRepository.SaveChangesAsync(cancellationToken);

            //}).ToList();