using I3Lab.Works.Domain.TreatmentInvites.Events;
using MediatR;

namespace I3Lab.Works.Application.TreatmentInvites.AcceptTreatmentInvite
{
    public class TreatmentInviteAcceptedDomainEventHandler : INotificationHandler<TreatmentInviteAcceptedDomainEvent>
    {
        public Task Handle(TreatmentInviteAcceptedDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
