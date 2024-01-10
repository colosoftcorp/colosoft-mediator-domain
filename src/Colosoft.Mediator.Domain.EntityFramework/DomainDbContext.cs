using Colosoft.Mediator;
using System.Data.Entity;

namespace Colosoft.Domain.EntityFramework
{
    public abstract class DomainDbContext : DbContext
    {
        private readonly IMediator mediator;

        protected DomainDbContext(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            await this.mediator.DispatchDomainEventsAsync(this, cancellationToken);
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
