using ReactiveCommons.api;
using ReactiveCommonsAsyncCommons.communications;
using ReactiveCommonsAsyncCommonsApi;

namespace ReactiveCommonsAsyncCommons;

public class QueryExecutor<T, M>
{
    private readonly IQueryHandlerDelegate<T, M> queryHandler;
    private readonly Func<IMessage, M> converter;

    public QueryExecutor(IQueryHandlerDelegate<T, M> queryHandler, Func<IMessage, M> converter)
    {
        this.queryHandler = queryHandler;
        this.converter = converter;
    }

    public Task<T> Execute(IMessage rawMessage)
    {
        var headers = rawMessage.GetProperties().GetHeaders();
        var correlationId = "";
        var replyId = "";
        if (headers.TryGetValue("x-correlation-id", out object correlationIdValue))
        {
            correlationId = correlationIdValue?.ToString() ?? string.Empty;
        }

        if (headers.TryGetValue("x-reply_id", out object replyIdValue))
        {
            replyId = replyIdValue?.ToString() ?? string.Empty;
        }

        var from = new From(
            replyId, correlationId
        );
        var query = converter(rawMessage);
        return queryHandler.Handle(from, query);
    }
}