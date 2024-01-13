using ReactiveCommons.api;

namespace ReactiveCommonsAsyncCommonsApi;

public interface IQueryHandlerDelegate<T, M> : IHandler
{
    Task<T> Handle(From var1, M var2);
}