using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using I3Lab.Users.Domain.Users.Events;
using I3Lab.Users.IntegrationEvents;
using MassTransit;
using MediatR;
using NSubstitute;
using Xunit;

namespace I3Lab.Users.Application.Register.Tests
{
    public class PublishIntegretionEventOnUserRegisteredDomainEventHandlerTests
    {
        private readonly IFixture _fixture;
        private readonly IPublishEndpoint _publisher;
        private readonly PublishIntegretionEventOnUserRegisteredDomainEventHandler _handler;

        public PublishIntegretionEventOnUserRegisteredDomainEventHandlerTests()
        {
            _fixture = new Fixture();
            _publisher = Substitute.For<IPublishEndpoint>();
            _handler = new PublishIntegretionEventOnUserRegisteredDomainEventHandler(_publisher);
        }

        [Fact]
        public async Task Handle_Should_Publish_UserRegisteredIntegrationEvent()
        {
            // Arrange
            var domainEvent = _fixture.Create<UserCreatedDomainEvent>();
            var cancellationToken = _fixture.Create<CancellationToken>();

            // Act
            await _handler.Handle(domainEvent, cancellationToken);

            // Assert
            await _publisher.Received(1).Publish(Arg.Any<UserRegisteredIntegretionEvent>());
        }
    }
}
