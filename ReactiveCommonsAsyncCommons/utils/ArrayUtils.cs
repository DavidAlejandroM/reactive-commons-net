namespace ReactiveCommonsAsyncCommons.utils;

public static class ArrayUtils
{
    public static T[] PrefixArray<T>(T head, T[] tail)
    {
        var objects = new List<T>(1 + tail.Length);
        objects.Add(head);
        objects.AddRange(tail);
        return objects.ToArray();
    }
}