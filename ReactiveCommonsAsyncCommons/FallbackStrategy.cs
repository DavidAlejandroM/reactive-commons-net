namespace ReactiveCommonsAsyncCommons;

public class FallbackStrategy
{
    public static readonly FallbackStrategy FastRetry = new FallbackStrategy("ATTENTION!! Fast retry message to same Queue: {0}");
    public static readonly FallbackStrategy DefinitiveDiscard = new FallbackStrategy("ATTENTION!! DEFINITIVE DISCARD!! of the message: {0}");
    public static readonly FallbackStrategy RetryDlq = new FallbackStrategy("ATTENTION!! Sending message to Retry DLQ: {0}");

    public string Message { get; }

    private FallbackStrategy(string message)
    {
        Message = message;
    }

    public override string ToString()
    {
        return Message;
    }
    
    public string FormatMessage(params object[] args)
    {
        return string.Format(Message, args);
    }
}
