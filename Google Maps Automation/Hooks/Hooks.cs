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
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions{Headless = false});
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