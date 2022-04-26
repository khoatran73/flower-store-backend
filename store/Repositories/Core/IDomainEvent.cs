namespace store.Repositories.Core;

public interface IDomainEvent : IEvent, INotification
{
  /// <summary>
  /// Represents the id of the command which generates the domain event.
  /// </summary>
  Guid? CommandId { get; set; }
}