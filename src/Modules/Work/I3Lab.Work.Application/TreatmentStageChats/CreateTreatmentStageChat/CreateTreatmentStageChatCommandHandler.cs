using MediatR;
using Microsoft.Extensions.Logging;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Domain.TreatmentStages;
using I3Lab.Treatments.Domain.TreatmentStageChats;
using I3Lab.Treatments.Application.Treatments.ApplicationErrors;

namespace I3Lab.Treatments.Application.TreatmentStageChats.CreatetreatmentStageChat
{
    public class CreateTreatmentStageChatCommandHandler(
        ITreatmentStageRepository workRepository,
        ITreatmentStageChatRepository treatmentStageChatRepository,
        ITreatmentRepository tretmentRepository,
        ILogger<CreateTreatmentStageChatCommandHandler> logger) : IRequestHandler<CreateTreatmentStageChatCommand>
    {
        public async Task Handle(CreateTreatmentStageChatCommand request, CancellationToken cancellationToken)
        {
            var treatmentStage = await workRepository.GetByIdAsync(new TreatmentStageId(request.TreatmentStageId));

            if (treatmentStage == null)
            {
                logger.LogWarning("TreatmentStage not found for TreatmentStageChatId: {TreatmentStageChatId}", request.TreatmentStageId);
                return;
            }
            var treatment = await tretmentRepository.GetByIdAsync(new TreatmentId(request.TreatmentId), cancellationToken);
            if (treatment is null)
            {
                logger.LogWarning(TreatmentsErrors.TreatmentNotFound);
                return;
            }

            var members = treatment.GetActiveTreatmentMembers();

            var treatmentStageChat = treatmentStage.CreateTreatmentStageChat(members);

            await treatmentStageChatRepository.AddAsync(treatmentStageChat);

            await treatmentStageChatRepository.SaveChangesAsync();

        }
    }
}
