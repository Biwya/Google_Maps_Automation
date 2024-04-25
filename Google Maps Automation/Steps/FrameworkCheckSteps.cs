using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using Reqnroll;

namespace GMAutomation;

[Binding]
public class FrameworkCheckSteps
{

    private PlaywrightSiteActions _playwrightSiteActions;

    public FrameworkCheckSteps(PlaywrightSiteActions playwrightSiteActions) 
    {
        _playwrightSiteActions = playwrightSiteActions;
    }

    [Given("the Playwright page is opened")]
    public async Task NavigateToPlaywrightMainPage()
    {
        await _playwrightSiteActions.UserInputsLink("https://playwright.dev/");
        _playwrightSiteActions.CheckUserIsOnUrl("https://playwright.dev/");
    }

    [When("the user clicks on the 'Get started' link")]
    public async Task UserClicksGetStartedLink()
    {
        await _playwrightSiteActions.UserClicksOnGettingStarted();
    }

    [Then("the user is redirected to the page with url ending with {string}")]
    public void UserRedirectedToUrl(string urlEnding)
    {
        _playwrightSiteActions.CheckUserIsOnUrl("https://playwright.dev/docs/intro");
    }
}