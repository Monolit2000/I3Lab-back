using I3Lab.Works.Domain.TreatmentInvites;
using I3Lab.Works.Domain.TreatmentInvites.Events;
using MediatR;

namespace I3Lab.Works.Application.TreatmentInvites.RejectTreatmentInvite
{
    public class TreatmentInviteRejectedDomainEventHandler : INotificationHandler<TreatmentInviteRejectedDomainEvent>
    {
        public Task Handle(TreatmentInviteRejectedDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
