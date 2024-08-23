using I3Lab.Users.Domain.Users.Events;
using I3Lab.Users.IntegrationEvents;
using MassTransit;
using MediatR;

namespace I3Lab.Users.Application.Register
{
    public class PublishIntegretionEventOnUserRegisteredDomainEventHandler(
        IPublishEndpoint publisher): INotificationHandler<UserCreatedDomainEvent>
    {
        public async Task Handle(UserCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            await publisher.Publish(new UserRegisteredIntegretionEvent(
                notification.UserId,
                notification.Name,
                notification.Email, 
                notification.LastName));  
        }
    }
}
