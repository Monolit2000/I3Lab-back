using MediatR;
using MassTransit;
using I3Lab.Clinics.IntegrationEvents;
using I3Lab.Clinics.Domain.DoctorCreationProposals.Events;

namespace I3Lab.Clinics.Application.DoctorCreationProposals.CreateDoctorCreationProposal
{
    public class PublishToIntegrationEventDoctorCreationProposalCreatedDomainEventHandler(
        IPublishEndpoint publishEndpoint) : INotificationHandler<DoctorCreationProposalCreatedDomainEvent>
    {
        public async Task Handle(DoctorCreationProposalCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            await publishEndpoint.Publish(new DoctorCreationProposalCreatedIntegrationEvent(
                notification.ProposalId,
                notification.FirstName,
                notification.LastName,
                notification.Email,
                notification.PhoneNumber,
                notification.DoctorAvatar,
                notification.CreatedAt));
        }
    }
}
