namespace ReactiveCommonsAsyncCommons.config;

public class BrokerConfig
{
    private readonly string _routingKey = Guid.NewGuid().ToString().Replace("-", "");
    private readonly bool _persistentQueries;
    private readonly bool _persistentCommands;
    private readonly bool _persistentEvents;
    private readonly TimeSpan _replyTimeout;

    public BrokerConfig()
    {
        _persistentQueries = false;
        _persistentCommands = true;
        _persistentEvents = true;
        _replyTimeout = TimeSpan.FromSeconds(15);
    }

    public BrokerConfig(bool persistentQueries, bool persistentCommands, bool persistentEvents, TimeSpan replyTimeout)
    {
        _persistentQueries = persistentQueries;
        _persistentCommands = persistentCommands;
        _persistentEvents = persistentEvents;
        _replyTimeout = replyTimeout;
    }

    public bool IsPersistentQueries()
    {
        return _persistentQueries;
    }

    public bool IsPersistentCommands()
    {
        return _persistentCommands;
    }

    public bool IsPersistentEvents()
    {
        return _persistentEvents;
    }

    public TimeSpan getReplyTimeout()
    {
        return _replyTimeout;
    }

    public string getRoutingKey()
    {
        return _routingKey;
    }
}