using I3Lab.Works.Application.Configuration.Commands;
using I3Lab.Works.Application.WorkChats.CreateWorkChat;
using I3Lab.Works.Domain.Works.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.Works.CreateWorks
{
    public class WorkCreatedDomainEventHandler(
        ISender sender,
        ICommandsScheduler commandsScheduler) : INotificationHandler<WorkCreatedDomainEvent>
    {
        public async Task Handle(WorkCreatedDomainEvent notification, CancellationToken cancellationToken)
        {

            await commandsScheduler.EnqueueAsync(new CreateWorkChatCommand(
                notification.WorkId.Value,
                notification.TreatmentId.Value));


            //await sender.Send(new CreateWorkChatCommand(
            //    notification.WorkId.Value, 
            //    notification.TreatmentId.Value));
        }
    }
}
