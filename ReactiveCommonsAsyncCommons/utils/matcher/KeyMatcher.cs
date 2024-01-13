namespace ReactiveCommonsAsyncCommons.utils.matcher;

public class KeyMatcher : IMatcher
{
    public static readonly string SeparatorRegex = "\\.";
    public static readonly string WildcardChar = "*";

    public string Match(HashSet<string> sources, string target)
    {
        if (sources.Contains(target) || sources.Count == 0)
            return target;

        return MatchMissingKey(sources, target);
    }

    private string MatchMissingKey(HashSet<string> names, string target)
    {
        return names.Where(name => name.Contains("*"))
            .OrderBy(name => name)
            .FirstOrDefault(name => WildcardMatch(target, name)) ?? target;
    }

    private bool WildcardMatch(string target, string pattern)
    {
        throw new NotImplementedException();
    }
}