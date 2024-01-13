namespace ReactiveCommonsAsyncCommons.exceptions;

using System;

public class MessageConversionException : Exception
{
    public MessageConversionException(string message, Exception cause) : base(message, cause)
    {
    }

    public MessageConversionException(string message) : base(message)
    {
    }

    public MessageConversionException(Exception e) : base(e.Message, e)
    {
    }
}
