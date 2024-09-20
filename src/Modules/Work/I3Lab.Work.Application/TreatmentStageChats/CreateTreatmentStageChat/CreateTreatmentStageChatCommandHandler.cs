using MediatR;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Domain.TreatmentStages;
using I3Lab.Treatments.Domain.TreatmentStageChats;

namespace I3Lab.Treatments.Application.WorkChats.CreateWorkChat
{
    public class CreateTreatmentStageChatCommandHandler(
        ITreatmentStageRepository workRepository,
        ITreatmentStageChatRepository workChatRepository,
        ITretmentRepository tretmentRepository) : IRequestHandler<CreateTreatmentStageChatCommand>
    {
        public async Task Handle(CreateTreatmentStageChatCommand request, CancellationToken cancellationToken)
        {
            var work = await workRepository.GetByIdAsync(new TreatmentStageId(request.WorkId));

            if (work == null)
                return;

            var treatment = await tretmentRepository.GetByIdAsync(new TreatmentId(request.TreatmentId), cancellationToken);

            var members = treatment.TreatmentMembers.Select(m => m.Member).ToList();

            var workChat = TreatmentStageChat.CreateBaseOnWork(new TreatmentStageId(request.WorkId), members);

            await workChatRepository.AddAsync(workChat);

            await workChatRepository.SaveChangesAsync();
        }
    }
}
