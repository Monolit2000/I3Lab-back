using I3Lab.Treatments.Application.Configuration.Commands;
using I3Lab.Treatments.Domain.Treatments.Events;
using I3Lab.Works.Application.TreatmentStageChats.AddChatMemberToAllTreatmentStageChatsByTreatmentId;
using MediatR;


namespace I3Lab.TreatmentStages.Application.Treatments.AddTreatmentMember
{
    public class TreatmentMemberAddedDomainEventHandler(
        ICommandsScheduler commandsScheduler) : INotificationHandler<TreatmentMemberAddedDomainEvent>
    {
        public async Task Handle(TreatmentMemberAddedDomainEvent notification, CancellationToken cancellationToken)
        {
            await commandsScheduler.EnqueueAsync(new AddChatMemberToAllTreatmentStageChatsByTreatmentIdCommand(
                notification.MemberId, 
                notification.TreatmentId));
        }
    }
}
