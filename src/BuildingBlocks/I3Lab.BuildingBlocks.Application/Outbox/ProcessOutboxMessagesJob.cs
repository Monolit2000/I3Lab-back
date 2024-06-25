using I3Lab.BuildingBlocks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.BuildingBlocks.Application.Outbox
{
    [DisallowConcurrentExecution]
    public class ProcessOutboxMessagesJob<T> : IJob where T : DbContext
    {
        private readonly T _dbContext;
        private readonly IPublisher _publisher;

        public ProcessOutboxMessagesJob(T context, IPublisher publisher)
        {
            _dbContext = context;
            _publisher = publisher;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            List<OutboxMessage> message = await _dbContext.Set<OutboxMessage>()
                .Where(m => m.ProcessedOnUtc == null)
                .Take(20)
                .ToListAsync(context.CancellationToken);

            foreach (var outboxMessage in message)
            {
                var domainEvent = JsonConvert
                    .DeserializeObject<IDomainEvent>(outboxMessage.Content);

                if (domainEvent is null)
                {
                    continue;
                }

                await _publisher.Publish(domainEvent, context.CancellationToken);

                outboxMessage.ProcessedOnUtc = DateTime.UtcNow;
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}
