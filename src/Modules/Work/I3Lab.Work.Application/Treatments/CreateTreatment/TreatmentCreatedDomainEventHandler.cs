using I3Lab.Works.Application.Works.CreateWork;
using I3Lab.Works.Domain.Treatments.Events;
using MediatR;

namespace I3Lab.Works.Application.Treatments.CreateTreatment
{
    public class TreatmentCreatedDomainEventHandler(
        ISender sender) : INotificationHandler<TreatmentCreatedDomainEvent>
    {
        public async Task Handle(TreatmentCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            await sender.Send(new CreateWorksCommand(
                    notification.TreatmentId, 
                    notification.CreatorId));
        }
    }
}
