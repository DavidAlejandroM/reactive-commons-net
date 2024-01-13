namespace ReactiveCommonsAsyncCommons.communications;

public interface IMessage
{
    byte[] GetBody();

    IProperties GetProperties();

    public interface IProperties
    {
        string GetContentType();

        string GetContentEncoding();

        long GetContentLength();

        IDictionary<string, object> GetHeaders();
    }
}