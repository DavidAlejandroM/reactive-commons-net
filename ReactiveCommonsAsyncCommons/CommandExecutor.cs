using ReactiveCommonsAsyncCommons.communications;
using ReactiveCommonsAsyncCommonsApi;
using ReactiveCommonsDomainEventsApi;

namespace ReactiveCommonsAsyncCommons;

public class CommandExecutor<T>
{
    private readonly ICommandHandler<T> _eventHandler;
    private readonly Func<IMessage, Command<T>> _converter;

    public CommandExecutor(ICommandHandler<T> eventHandler, Func<IMessage, Command<T>> converter)
    {
        _eventHandler = eventHandler;
        _converter = converter;
    }

    public Task Execute(IMessage rawMessage)
    {
        var command = _converter(rawMessage);
        return _eventHandler.Handler(command);
    }
}