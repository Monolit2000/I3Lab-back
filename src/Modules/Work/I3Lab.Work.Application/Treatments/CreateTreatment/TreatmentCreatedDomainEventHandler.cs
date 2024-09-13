using I3Lab.Works.Application.Configuration.Commands;
using I3Lab.Works.Application.Works.CreateWorks;
using I3Lab.Works.Domain.Treatments.Events;
using MediatR;

namespace I3Lab.Works.Application.Treatments.CreateTreatment
{
    public class TreatmentCreatedDomainEventHandler(
        ICommandsScheduler commandsScheduler,
        ISender sender) : INotificationHandler<TreatmentCreatedDomainEvent>
    {
        public async Task Handle(TreatmentCreatedDomainEvent notification, CancellationToken cancellationToken)
        {

            await commandsScheduler.EnqueueAsync(new CreateWorksCommand(
                Guid.NewGuid(),
                notification.TreatmentId,
                notification.CreatorId));

            //await sender.Send(new CreateWorksCommand(
            //        notification.TreatmentId, 
            //        notification.CreatorId));
        }
    }
}
