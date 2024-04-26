using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using Reqnroll;

namespace GMAutomation;

[Binding]
public class FrameworkCheckSteps
{

    private readonly PlaywrightSiteActions _playwrightSiteActions;
    private readonly CommonPageActions _commonPageActions;

    public FrameworkCheckSteps(PlaywrightSiteActions playwrightSiteActions, CommonPageActions commonPageActions) 
    {
        _playwrightSiteActions = playwrightSiteActions;
        _commonPageActions = commonPageActions;
    }

    [When("the user clicks on the 'Get started' link")]
    public async Task UserClicksGetStartedLink()
    {
        await _playwrightSiteActions.UserClicksOnGettingStarted();
    }

    [Then("the user is redirected to the page with url ending with {string}")]
    public void UserRedirectedToUrl(string urlEnding)
    {
        _commonPageActions.CheckUserIsOnUrl("https://playwright.dev/docs/intro");
    }
}