namespace ReactiveCommonsAsyncCommons.config;

public interface IBrokerConfigProps
{
    string EventsQueue { get; }

    string QueriesQueue { get; }

    string CommandsQueue { get; }

    string ReplyQueue { get; }

    string AppName { get; }

    string DomainEventsExchangeName { get; }

    string DirectMessagesExchangeName { get; }

    string ReplyQueueName { get; }
}