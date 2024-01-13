namespace ReactiveCommonsDomainEventsApi;

public interface IDomainEventBus
{
    Task Emit<T>(DomainEvent<T> domainEvent);
}