using ReactiveCommonsAsyncCommons.communications;

namespace ReactiveCommonsAsyncCommons.reply;

using System;
using System.Collections.Concurrent;
using System.Reactive.Subjects;
using System.Threading.Tasks;

public class ReactiveReplyRouter
{
    private readonly ConcurrentDictionary<string, Subject<IMessage>> _processors = new ConcurrentDictionary<string, Subject<IMessage>>();

    public ReactiveReplyRouter()
    {
    }

    public Task<IMessage> Register(string correlationID)
    {
        var processor = new Subject<IMessage>();
        _processors[correlationID] = processor;

        var tcs = new TaskCompletionSource<IMessage>();
        processor.Subscribe(
            onNext: message => tcs.TrySetResult(message),
            onError: exception => tcs.TrySetException(exception),
            onCompleted: () => tcs.TrySetResult(null));

        return tcs.Task;
    }

    public void RouteReply(string correlationID, IMessage data)
    {
        if (_processors.TryRemove(correlationID, out var processor))
        {
            processor.OnNext(data);
            processor.OnCompleted();
        }
    }

    public void Deregister(string correlationID)
    {
        _processors.TryRemove(correlationID, out _);
    }

    public void RouteEmpty(string correlationID)
    {
        if (_processors.TryRemove(correlationID, out var processor))
        {
            processor.OnCompleted();
        }
    }
}

