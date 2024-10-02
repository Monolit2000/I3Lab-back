using I3Lab.Treatments.Application.Configuration.Commands;
using I3Lab.Treatments.Application.Works.CreateWorks;
using I3Lab.Treatments.Domain.Treatments.Events;
using MediatR;

namespace I3Lab.Treatments.Application.Treatments.CreateTreatment
{
    public class TreatmentCreatedDomainEventHandler(
        ICommandsScheduler commandsScheduler,
        ISender sender) : INotificationHandler<TreatmentCreatedDomainEvent>
    {
        public async Task Handle(TreatmentCreatedDomainEvent notification, CancellationToken cancellationToken)
        {

            await commandsScheduler.EnqueueAsync(new CreateWorksCommand(
                notification.TreatmentId,
                notification.CreatorId));

            //await sender.Send(new CreateWorksCommand(
            //        notification.TreatmentId,
            //        notification.CreatorId));
        }
    }
}
