using ReactiveCommonsAsyncCommons.communications;

namespace ReactiveCommonsAsyncCommons;

public interface IDiscardNotifier
{
    Task notifyDiscard(IMessage var1);
}