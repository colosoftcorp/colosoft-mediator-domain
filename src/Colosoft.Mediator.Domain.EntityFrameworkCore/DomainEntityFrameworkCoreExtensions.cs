﻿using Colosoft.Mediator;
using Microsoft.EntityFrameworkCore;

namespace Colosoft.Domain
{
    public static class DomainEntityFrameworkCoreExtensions
    {
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, DbContext ctx, CancellationToken cancellationToken)
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            foreach (var domainEvent in domainEvents)
            {
                await mediator.Publish(domainEvent, cancellationToken);
            }
        }
    }
}
