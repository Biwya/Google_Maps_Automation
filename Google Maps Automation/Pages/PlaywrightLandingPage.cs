using Microsoft.Playwright;

namespace GMAutomation;

public class PlaywrightLandingPage
{
    private readonly IPage _page;
    public ILocator GetStartedButton { get;}

    public PlaywrightLandingPage(Hooks hooks) 
    {
        _page = hooks.Page;
        GetStartedButton = _page.GetByText("Get started");
    }
}