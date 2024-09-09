using I3Lab.Works.Domain.TreatmentInvites.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.TreatmentInvites.CreateTreatmentInvite
{
    public class TreatmentInviteCreatedDomainEventHandler : INotificationHandler<TreatmentInviteCreatedDomainEvent>
    {
        public Task Handle(TreatmentInviteCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
