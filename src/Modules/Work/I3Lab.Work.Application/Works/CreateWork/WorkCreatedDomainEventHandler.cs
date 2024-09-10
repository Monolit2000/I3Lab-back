using I3Lab.Works.Application.WorkChats.CreateWorkChat;
using I3Lab.Works.Domain.Works.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.Works.CreateWork
{
    public class WorkCreatedDomainEventHandler(
        ISender sender) : INotificationHandler<WorkCreatedDomainEvent>
    {
        public async Task Handle(WorkCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            await sender.Send(new CreateWorkChatCommand(
                notification.WorkId.Value, 
                notification.TreatmentId.Value));
        }
    }
}
