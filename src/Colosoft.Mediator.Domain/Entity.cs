using Colosoft.Mediator;

namespace Colosoft.Domain
{
    public abstract class Entity : IEntity
    {
        private List<INotification>? domainEvents;

        public IEnumerable<INotification> DomainEvents => this.domainEvents?.AsReadOnly() ?? Enumerable.Empty<INotification>();

        public void AddDomainEvent(INotification eventItem)
        {
            this.domainEvents = this.domainEvents ?? new List<INotification>();
            this.domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            this.domainEvents?.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            this.domainEvents?.Clear();
        }
    }
}
