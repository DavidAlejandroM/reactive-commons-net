using ReactiveCommonsAsyncCommons.communications;
using ReactiveCommonsAsyncCommonsApi;
using ReactiveCommonsDomainEventsApi;

namespace ReactiveCommonsAsyncCommons.utils;

public class EventExecutor<T>
{
    private readonly IEventHandler<T> _eventHandler;
    private readonly Func<IMessage, DomainEvent<T>> _converter;
    
    public EventExecutor(IEventHandler<T> eventHandler, Func<IMessage, DomainEvent<T>> converter)
    {
        _eventHandler = eventHandler;
        _converter = converter;
    }
    
    public Task Execute(IMessage rawMessage)
    {
        var domainEvent = _converter(rawMessage);
        return _eventHandler.Handler(domainEvent);
    }
}