using Colosoft.Mediator;
using Microsoft.EntityFrameworkCore;

namespace Colosoft.Domain.EntityFrameworkCore
{
    public abstract class DomainDbContext : DbContext
    {
        private readonly IMediator mediator;

        protected DomainDbContext(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            await this.mediator.DispatchDomainEventsAsync(this, cancellationToken);
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
