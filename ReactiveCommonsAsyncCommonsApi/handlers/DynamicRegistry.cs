namespace ReactiveCommonsAsyncCommonsApi;

public interface DynamicRegistry
{
    [Obsolete("Deprecated")]
    Task ListenEvent<T>(string eventName, EventHandler<T> eventHandler, Type eventType);

    void ServeQuery<T, R>(string queryName, IQueryHandler<T, R> queryHandler, Type responseType);

    void ServeQuery<R>(string queryName, IQueryHandlerDelegate<bool, R> queryHandler, Type responseType);
    
    Task StartListeningEvent(string eventName);

    Task StopListeningEvent(string eventName);
}