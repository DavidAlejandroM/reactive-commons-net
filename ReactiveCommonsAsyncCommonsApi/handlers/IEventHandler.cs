

using ReactiveCommonsDomainEventsApi;

namespace ReactiveCommonsAsyncCommonsApi;

public interface IEventHandler<T> : IGenericHandler<Task, DomainEvent<T>>, IHandler
{
    
}