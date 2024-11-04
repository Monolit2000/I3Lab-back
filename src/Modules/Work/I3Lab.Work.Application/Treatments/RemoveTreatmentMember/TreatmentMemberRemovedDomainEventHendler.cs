using MediatR;
using I3Lab.Treatments.Domain.Treatments.Events;
using I3Lab.Treatments.Application.Configuration.Commands;
using I3Lab.Treatments.Application.TreatmentStageChats.RemoveChatMember;
using I3Lab.Treatments.Application.TreatmentStageChats.RemoveChatMemberWithAllChats;

namespace I3Lab.Treatments.Application.Treatments.RemoveTreatmentMember
{
    public class TreatmentMemberRemovedDomainEventHendler(
        IHangFireCommandsScheduler hangFireCommandsScheduler) : INotificationHandler<MemberRemovedFromTreatmentDomainEvent>
    {
        public async Task Handle(MemberRemovedFromTreatmentDomainEvent notification, CancellationToken cancellationToken)
        {
            await hangFireCommandsScheduler.EnqueueAsync(
                new RemoveChatMemberFromAllTreatmentStageChatsCommand(
                    notification.MemberId,
                    notification.TreatmentId));
        }
    }
}
