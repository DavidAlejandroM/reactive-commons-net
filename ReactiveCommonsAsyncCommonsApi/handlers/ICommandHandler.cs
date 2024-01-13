using ReactiveCommonsDomainEventsApi;

namespace ReactiveCommonsAsyncCommonsApi;

public interface ICommandHandler<T> : IGenericHandler<Task, Command<T>>
{
}