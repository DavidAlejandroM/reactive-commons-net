using ReactiveCommonsDomainEventsApi;

namespace ReactiveCommons.api;

public interface DirectAsyncGateway
{
    Task SendCommand<T>(Command<T> command, string path);

    Task<R> RequestReply<T, R>(AsyncQuery<T> query, string path, Type responseType);

    Task Reply<T>(T response, From from);
}