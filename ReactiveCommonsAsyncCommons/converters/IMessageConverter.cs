using ReactiveCommons.api;
using ReactiveCommonsAsyncCommons.communications;
using ReactiveCommonsDomainEventsApi;

namespace ReactiveCommonsAsyncCommons.converters;

public interface IMessageConverter
{
    AsyncQuery<T> ReadAsyncQuery<T>(IMessage message, Type type);

    DomainEvent<T> ReadDomainEvent<T>(IMessage message, Type type);

    Command<T> ReadCommand<T>(IMessage message, Type type);

    T ReadValue<T>(IMessage message, Type type);

    Command<T> ReadCommandStructure<T>(IMessage message);

    DomainEvent<T> ReadDomainEventStructure<T>(IMessage message);

    AsyncQuery<T> ReadAsyncQueryStructure<T>(IMessage message);

    IMessage ToMessage(object value);
}