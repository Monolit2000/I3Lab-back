using I3Lab.BuildingBlocks.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.BuildingBlocks.Application.Outbox
{
    public sealed class ConvertDomainEventsToOutboxMessageIterseptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {
            DbContext? dbContext = eventData.Context;

            if (dbContext is null)
            {
                return base.SavingChangesAsync(eventData, result, cancellationToken);
            }

            var outboxMessage = dbContext.ChangeTracker
                .Entries<Entity>()
                .Select(x => x.Entity)
                .SelectMany(x =>
                {
                    var domainEvents = x.GetDomainEvents();

                    x.ClearDomainEvents();

                    return domainEvents;
                })
                .Select(domainEvent => new OutboxMessage
                {
                    Id = Guid.NewGuid(),
                    OccurredOnUtc = DateTime.UtcNow,
                    Type = domainEvent.GetType().Name,
                    Content = JsonConvert.SerializeObject(
                        domainEvent,
                        new JsonSerializerSettings
                        {
                            TypeNameHandling = TypeNameHandling.All
                        })
                })
                .ToList();

            dbContext.Set<OutboxMessage>().AddRange(outboxMessage);

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

    }
}
