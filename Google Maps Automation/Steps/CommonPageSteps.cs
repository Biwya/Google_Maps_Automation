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
    public async Task userAccessesLink(string url) 
    {
        await _commonPageActions.UserInputsLink(url);
    }

    [When("the page loads")]
    public async Task pageLoads()
    {
        await _commonPageActions.WaitForPageLoad();
    }

    [Then("the url starts with {string}")]
    public void urlStartsWith(string urlStart)
    {
        _commonPageActions.CheckUserIsOnUrlStartingWith(urlStart);
    }

    [Then("the url is {string}")]
    public void urlIs(string url)
    {
        _commonPageActions.CheckUserIsOnUrl(url);
    }
}