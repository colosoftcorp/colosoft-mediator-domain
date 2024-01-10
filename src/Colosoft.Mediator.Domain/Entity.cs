using Colosoft.Mediator;

namespace Colosoft.Domain
{
    public abstract class Entity : IEntity, IDomainEventsContainer
    {
        private List<INotification>? domainEvents;

        public IEnumerable<INotification> DomainEvents => this.domainEvents?.AsReadOnly() ?? Enumerable.Empty<INotification>();

        public void AddDomainEvent(INotification notification)
        {
            if (notification is null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            this.domainEvents = this.domainEvents ?? new List<INotification>();
            this.domainEvents.Add(notification);
        }

        public void RemoveDomainEvent(INotification notification)
        {
            if (notification is null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            this.domainEvents?.Remove(notification);
        }

        public void ClearDomainEvents()
        {
            this.domainEvents?.Clear();
        }
    }
}
