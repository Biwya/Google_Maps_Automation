namespace GMAutoamtion;

public class EnvironmentConfig
{
    public static string GetBrowserType()
    {
        if(System.Environment.GetEnvironmentVariable("BROWSER") == null)
        {
            System.Environment.SetEnvironmentVariable("BROWSER", "chrome");
        }
        return System.Environment.GetEnvironmentVariable("BROWSER");
    }

    public static bool GetHeadless()
    {
        if (System.Environment.GetEnvironmentVariable("HEADLESS") == null || System.Environment.GetEnvironmentVariable("HEADLESS") == "true")
        {
            return true;
        }
        return false;
    }
}