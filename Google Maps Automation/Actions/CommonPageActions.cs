using Microsoft.Playwright;
using NUnit.Framework.Constraints;

namespace GMAutomation;

public class CommonPageActions
{
    private readonly IPage _page;

    public CommonPageActions(Hooks hooks)
    {
        _page = hooks.Page;
    }

    public void CheckUserIsOnUrl(string url)
    {
        Assert.That(_page.Url, Is.EqualTo(url), $"The user did not land on the expected page of {url}, but is instead on {_page.Url}");
    }

    public void CheckUserIsOnUrlContaining(string urlSection) 
    {
        Assert.That(_page.Url, Contains.Substring(urlSection), $"The user did not land on the expected url containing {urlSection}, but is instead on {_page.Url}");
    }

    public void CheckUserIsOnUrlStartingWith(string urlStart)
    {
        Assert.That(_page.Url, new StartsWithConstraint(urlStart), $"The user did not land on the expected url starting with {urlStart}, but is instead on {_page.Url}");
    }

    public async Task UserInputsLink(string url)
    {
        await _page.GotoAsync(url);
    }

    public async Task WaitForPageLoad()
    {
        await _page.WaitForLoadStateAsync();
    }

    public async Task WaitForPageNetworkIdle()
    {
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

    public async Task WaitForConditionToBeTrue(Task<bool> condition, int numberOfRetries = 10, int waitIntervalMs = 200)
    {
        for (int retry = 0; retry < numberOfRetries; retry++)
        {
            if (condition.Result){
                break;
            }
            await _page.WaitForTimeoutAsync(waitIntervalMs);
        }
    }

    public void CheckPageDisplayLanguage(string language)
    {
        string languageId;
        switch (language.ToLower()) 
        {
            case "english": languageId = "en"; break;
            case "german": languageId = "de"; break;
            default: throw new ArgumentException($"The page cannot be chacked for the following language {language};");
        }
        Assert.True(_page.Locator("//html").GetAttributeAsync("lang").Result.Contains(languageId));
    }

}