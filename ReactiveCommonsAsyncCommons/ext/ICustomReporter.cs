using ReactiveCommons.api;
using ReactiveCommonsAsyncCommons.communications;
using ReactiveCommonsDomainEventsApi;

namespace ReactiveCommonsAsyncCommons.ext;

using System;
using System.Threading.Tasks;

public interface ICustomReporter
{
    Task ReportMetric(string type, string handlerPath, long duration, bool success);

    Task ReportError(Exception ex, IMessage rawMessage, Command<object> command, bool redelivered);

    Task ReportError(Exception ex, IMessage rawMessage, DomainEvent<object> domainEvent, bool redelivered);

    Task ReportError(Exception ex, IMessage rawMessage, AsyncQuery<object> asyncQuery, bool redelivered);
}

public static class MessageTypes
{
    public const string CommandClass = "org.reactivecommons.api.domain.Command";
    public const string EventClass = "org.reactivecommons.api.domain.DomainEvent";
    public const string QueryClass = "org.reactivecommons.async.api.AsyncQuery";
}
