namespace store.Repositories.Core;

public interface IEvent : INotification
{
    Guid Id { get; }

    DateTimeOffset Timestamp { get; }
}