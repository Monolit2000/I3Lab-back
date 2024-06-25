using MediatR;
using I3Lab.BuildingBlocks.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;


namespace I3Lab.BuildingBlocks.Infrastructure.Domain
{
    public class DispatchDomainEventsInterceptor : SaveChangesInterceptor
    {
        private readonly IMediator _mediator;

        public DispatchDomainEventsInterceptor(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            DispatchDomainEvents(eventData.Context).GetAwaiter().GetResult();

            return base.SavingChanges(eventData, result);

        }

        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            await DispatchDomainEvents(eventData.Context);

            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        public async Task DispatchDomainEvents(DbContext? context)
        {
            if (context == null) return;

            var entities = context.ChangeTracker
                .Entries<Entity>()
                .Where(e => e.Entity.DomainEvents.Any())
                //.Where(e => e.Entity != null && e.Entity.DomainEvents.Any())
                .Select(e => e.Entity);

            var domainEvents = entities
                .SelectMany(e => e.DomainEvents)
                .ToList();

            entities.ToList().ForEach(e => e.ClearDomainEvents());

            foreach (var domainEvent in domainEvents)
                await _mediator.Publish(domainEvent);
        }
    }
}
