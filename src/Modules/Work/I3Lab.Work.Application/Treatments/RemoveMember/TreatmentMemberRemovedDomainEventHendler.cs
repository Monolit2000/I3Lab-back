using MediatR;
using I3Lab.Treatments.Domain.Treatments.Events;
using I3Lab.Treatments.Application.Configuration.Commands;
using I3Lab.Treatments.Application.TreatmentStageChats.RemoveChatMember;
using I3Lab.Works.Application.TreatmentStageChats.RemoveChatMemberWithAllChats;

namespace I3Lab.Works.Application.Treatments.RemoveMember
{
    public class TreatmentMemberRemovedDomainEventHendler(
        ICommandsScheduler commandsScheduler) : INotificationHandler<MemberRemovedFromTreatmentDomainEvent>
    {
        public async Task Handle(MemberRemovedFromTreatmentDomainEvent notification, CancellationToken cancellationToken)
        {
            await commandsScheduler.EnqueueAsync(
                new RemoveChatMemberFromAllTreatmentStageChatsCommand(
                    notification.MemberId,
                    notification.TreatmentId));
        }
    }
}
