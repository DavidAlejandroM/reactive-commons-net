
using System.Reflection;
using ReactiveCommonsAsyncCommonsApi.registered;


namespace ReactiveCommonsAsyncCommonsApi;

public class HandlerRegistry
{
    private List<IHandler> eventListeners = new List<IHandler>();
    private List<IHandler> dynamicEventHandlers = new List<IHandler>();
    private List<IHandler> eventNotificationListener = new List<IHandler>();
    private List<IHandler> handlers = new List<IHandler>();
    private List<IHandler> commandHandlers = new List<IHandler>();


    public static HandlerRegistry Register()
    {
        return new HandlerRegistry();
    }

    public HandlerRegistry ListenEvent<T>(string eventName, IEventHandler<T> handler, Type eventClass)
    {
        eventListeners.Add(new RegisteredEventListener<T>(eventName, handler, eventClass));
        return this;
    }

    public HandlerRegistry ListenEvent<T>(string eventName, IEventHandler<T> handler)
    {
        return ListenEvent(eventName, handler, InferGenericParameterType(handler));
    }

    public HandlerRegistry ListenNotificationEvent<T>(string eventName, IEventHandler<T> handler, Type eventClass)
    {
        eventNotificationListener.Add(new RegisteredEventListener<T>(eventName, handler, eventClass));
        return this;
    }

    public HandlerRegistry HandleDynamicEvents<T>(string eventNamePattern, IEventHandler<T> handler, Type eventClass)
    {
        dynamicEventHandlers.Add(new RegisteredEventListener<T>(eventNamePattern, handler, eventClass));
        return this;
    }

    public HandlerRegistry HandleDynamicEvents<T>(string eventNamePattern, IEventHandler<T> handler)
    {
        return HandleDynamicEvents(eventNamePattern, handler, InferGenericParameterType(handler));
    }

    public HandlerRegistry HandleCommand<T>(string commandName, ICommandHandler<T> fn, Type commandClass)
    {
        commandHandlers.Add(new RegisteredCommandHandler<T>(commandName, fn, commandClass));
        return this;
    }

    public HandlerRegistry HandleCommand<T>(string commandName, ICommandHandler<T> fn)
    {
        return HandleCommand(commandName, fn, InferGenericParameterType(fn));
    }

    // public HandlerRegistry ServeQuery<T, R>(string resource, IQueryHandler<T, R> handler, Type queryClass)
    // {
    //     handlers.Add(new RegisteredQueryHandler<T, R>(resource, handler.Handler(), queryClass));
    //
    //     return this;
    // }

    // public HandlerRegistry ServeQuery<T, R>(string resource, IQueryHandler<T, R> handler)
    // {
    //     return ServeQuery(resource, handler, InferGenericParameterType(handler));
    // }

    private Type InferGenericParameterType<T>(T handler)
    {
        try
        {
            var genericInterfaces = handler.GetType().GetInterfaces();
            var parameterizedType = genericInterfaces[0] as TypeInfo;
            return parameterizedType.GenericTypeArguments[0];
        }
        catch (Exception)
        {
            throw new InvalidOperationException("Fail to infer generic type, please use the method with the type parameter explicitly.");
        }
    }
}