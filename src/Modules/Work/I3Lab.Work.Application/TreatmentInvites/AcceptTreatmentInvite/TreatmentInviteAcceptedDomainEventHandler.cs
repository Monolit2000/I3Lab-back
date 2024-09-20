using I3Lab.Treatments.Application.Treatments.AddTreatmentMember;
using I3Lab.Treatments.Domain.TreatmentInvites.Events;
using MediatR;

namespace I3Lab.Treatments.Application.TreatmentInvites.AcceptTreatmentInvite
{
    public class TreatmentInviteAcceptedDomainEventHandler(
         ISender sender) : INotificationHandler<TreatmentInviteAcceptedDomainEvent>
    {
        public async Task Handle(TreatmentInviteAcceptedDomainEvent notification, CancellationToken cancellationToken)
        {
            await sender.Send(new AddTreatmentMemberCommand(
                notification.TreatmentId.Value, 
                notification.InviterId.Value,
                notification.InviteeId.Value));
        }
    }
}
