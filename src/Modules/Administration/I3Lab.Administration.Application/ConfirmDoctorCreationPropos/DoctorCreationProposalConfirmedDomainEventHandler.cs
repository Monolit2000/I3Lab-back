using I3Lab.Administration.Domain.DoctorCreationProposals.Events;
using I3Lab.Administration.IntegrationEvents;
using MassTransit;
using MediatR;

namespace I3Lab.Administration.Application.ConfirmDoctorCreationPropos
{
    public class DoctorCreationProposalConfirmedDomainEventHandler(
        IPublishEndpoint publishEndpoint) : INotificationHandler<DoctorCreationProposalConfirmedDomainEvent>
    {
        public async Task Handle(DoctorCreationProposalConfirmedDomainEvent notification, CancellationToken cancellationToken)
        {
            await publishEndpoint
                .Publish(new DoctorCreationProposalConfirmedIntegrationEvent(notification.DoctorCreationProposalId.Value));
        }
    }
}
  