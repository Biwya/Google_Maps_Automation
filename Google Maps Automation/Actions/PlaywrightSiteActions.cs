using Microsoft.Playwright;

namespace GMAutomation;

public class PlaywrightSiteActions
{
    private readonly PlaywrightLandingPage _playwrightLanginPage;

    public PlaywrightSiteActions(PlaywrightLandingPage playwrightLandingPage)
    {
        _playwrightLanginPage = playwrightLandingPage;
    }

    public async Task UserClicksOnGettingStarted()
    {
        await _playwrightLanginPage.GetStartedButton.ClickAsync();
    }
}