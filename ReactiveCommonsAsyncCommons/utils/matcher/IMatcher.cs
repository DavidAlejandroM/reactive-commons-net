namespace ReactiveCommonsAsyncCommons.utils.matcher;

public interface IMatcher
{
    string Match(HashSet<string> sources, string target);
}