using I3Lab.Treatments.Application.Configuration.Commands;
using I3Lab.Treatments.Application.TreatmentStageChats.CreatetreatmentStageChat;
using I3Lab.Treatments.Domain.TreatmentStages.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.Works.CreateWorks
{
    public class TreatmentStageCreatedDomainEventHandler(
        ISender sender,
        IHangFireCommandsScheduler hangFireCommandsScheduler) : INotificationHandler<WorkCreatedDomainEvent>
    {
        public async Task Handle(WorkCreatedDomainEvent notification, CancellationToken cancellationToken)
        {

            await hangFireCommandsScheduler.EnqueueAsync(new CreateTreatmentStageChatCommand(
                notification.TreatmentStageId.Value,
                notification.TreatmentId.Value));


            //await sender.Send(new CreateTreatmentStageChatCommand(
            //    notification.TreatmentStageId.Value,
            //    notification.TreatmentId.Value));
        }
    }
}
