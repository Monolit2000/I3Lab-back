using I3Lab.Works.Domain.TreatmentInvites.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
