namespace store.Repositories.Core;

public interface IEntity<TKey> : IEntityCore
{
    TKey Id { get; set; }

    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

    void AddDomainEvent(IDomainEvent eventItem);

    void RemoveDomainEvent(IDomainEvent eventItem);

    void ClearDomainEvents();
}