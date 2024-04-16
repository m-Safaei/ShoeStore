namespace ShoeStore.Application.Utilities;

public class NameGenerator
{
    public static string GenerateUniqCode()
    {
        return Guid.NewGuid().ToString().Replace("-", "");
    }
}

