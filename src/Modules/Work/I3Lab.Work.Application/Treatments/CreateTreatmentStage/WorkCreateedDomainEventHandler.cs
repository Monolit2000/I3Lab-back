using I3Lab.Works.Domain.Works.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.Treatments.CreateTreatmentStage
{
    public class WorkCreateedDomainEventHandler : INotificationHandler<WorkCreatedDomainEvent>
    {
        public Task Handle(WorkCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
