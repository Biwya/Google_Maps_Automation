using Microsoft.Playwright;

namespace GMAutomation;

public class PlaywrightSiteActions
{
    private readonly IPage _page;
    private readonly PlaywrightLandingPage _playwrightLanginPage;

    public PlaywrightSiteActions(Hooks hooks, PlaywrightLandingPage playwrightLandingPage)
    {
        _page = hooks.Page;
        _playwrightLanginPage = playwrightLandingPage;
    }

    public async Task UserInputsLink(string url)
    {
        await _page.GotoAsync(url);
    }

    public void CheckUserIsOnUrl(string url)
    {
        Assert.That(_page.Url, Is.EqualTo(url), $"The user dod not land on the expected page of {url}, but is instead on {_page.Url}");
    }

    public async Task UserClicksOnGettingStarted()
    {
        await _playwrightLanginPage.GetStartedButton.ClickAsync();
    }
}