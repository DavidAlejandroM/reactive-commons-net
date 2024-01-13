namespace ReactiveCommonsAsyncCommons.exceptions;

using System;

public class SendFailureNoAckException : Exception
{
    public SendFailureNoAckException(string message) : base(message)
    {
    }
}
