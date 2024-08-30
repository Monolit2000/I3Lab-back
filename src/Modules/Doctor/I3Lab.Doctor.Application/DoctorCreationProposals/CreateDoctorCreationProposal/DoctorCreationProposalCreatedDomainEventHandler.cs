using MediatR;
using MassTransit;
using I3Lab.Doctors.IntegrationEvents;
using I3Lab.Doctors.Domain.DoctorCreationProposals.Events;

namespace I3Lab.Doctors.Application.DoctorCreationProposals.CreateDoctorCreationProposal
{
    public class DoctorCreationProposalCreatedDomainEventHandler(
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
