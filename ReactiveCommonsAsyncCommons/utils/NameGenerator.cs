namespace ReactiveCommonsAsyncCommons.utils;

public class NameGenerator
{
    public NameGenerator()
    {
    }

    public static string GenerateNameFrom(string applicationName, string suffix)
    {
        return GenerateName(applicationName, suffix);
    }

    public static string GenerateNameFrom(string applicationName)
    {
        return GenerateName(applicationName, "");
    }

    private static string GenerateName(string applicationName, string suffix)
    {
        var uuid = Guid.NewGuid();
        var bytes = uuid.ToByteArray();
        return $"{applicationName}-{suffix}-{EncodeToUrlSafeString(bytes).Replace("=", "")}";
    }

    private static string EncodeToUrlSafeString(byte[] src)
    {
        return Convert.ToBase64String(src).Replace('+', '-').Replace('/', '_');
    }
}