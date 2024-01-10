using Colosoft.Mediator;

namespace Colosoft.Domain
{
    public interface IDomainEventsContainer
    {
        IEnumerable<INotification> DomainEvents { get; }

        void AddDomainEvent(INotification notification);

        void RemoveDomainEvent(INotification notification);

        void ClearDomainEvents();
    }
}
