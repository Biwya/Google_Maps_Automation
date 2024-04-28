using Reqnroll;

namespace GMAutomation;

[Binding]
public class CommonPageSteps
{
    private readonly CommonPageActions _commonPageActions;

    public CommonPageSteps(CommonPageActions commonPageActions)
    {
        _commonPageActions = commonPageActions;
    }

    [Given("the user accesses the {string} link")]
    public async Task UserAccessesLink(string url) 
    {
        await _commonPageActions.UserInputsLink(url);
    }

    [When("the page loads")]
    public async Task PageLoads()
    {
        await _commonPageActions.WaitForPageLoad();
    }

    [Then("the url starts with {string}")]
    public void UrlStartsWith(string urlStart)
    {
        _commonPageActions.AssertUserIsOnUrlStartingWith(urlStart);
    }

    [Then("the url is {string}")]
    public void UrlIs(string url)
    {
        _commonPageActions.AssertUserIsOnUrl(url);
    }

    [Then("the url contains {string}")]
    public void UrlContains(string urlSection)
    {
        _commonPageActions.AssertUserIsOnUrlContaining(urlSection);
    }
}