using GMAutoamtion;
using Microsoft.Playwright;
using Reqnroll;

namespace GMAutomation;

[Binding]
public class Hooks
{
    public IPage Page { get; private set; } = null;

    [Before]
    public async Task SetupBrowser()
    {
        var playwright = await Playwright.CreateAsync();
        IBrowser browser;
        switch (EnvironmentConfig.GetBrowserType().ToLower())
        {
            case "chrome": browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = EnvironmentConfig.GetHeadless() }); break;
            case "firefox": browser = await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions { Headless = EnvironmentConfig.GetHeadless() }); break;
            case "webkit": browser = await playwright.Webkit.LaunchAsync(new BrowserTypeLaunchOptions { Headless = EnvironmentConfig.GetHeadless() }); break;
            default: browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = EnvironmentConfig.GetHeadless() }); break;
        }
        var browserContext = await browser.NewContextAsync();
        Page = await browserContext.NewPageAsync();
        await Page.SetViewportSizeAsync(1920, 1080);
    }

    [After]
    public async Task CloseBrowser()
    {
        await Page.CloseAsync();
    }
}