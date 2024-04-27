using System.Diagnostics.CodeAnalysis;

namespace GMAutomation;

public class GoogleMapsActions
{
    private readonly GoogleMapsPage _googleMapsPage;
    private readonly CommonPageActions _commonPageActions;

    public GoogleMapsActions(GoogleMapsPage googleMapsPage, CommonPageActions commonPageActions)
    {
        _googleMapsPage = googleMapsPage;
        _commonPageActions = commonPageActions;
    }

    public async Task ClickBurgerMenu()
    {
        await _commonPageActions.WaitForPageNetworkIdle();
        await _googleMapsPage.HamburgerMenu.ClickAsync();
        await _commonPageActions.WaitForConditionToBeTrue(_googleMapsPage.SettingsMenu.IsVisibleAsync());
    }

    public void CheckSettingsMenuIsVisible()
    {
        Assert.That(_googleMapsPage.SettingsMenu.IsVisibleAsync().Result, Is.True);
    }

    public async Task ClickLanguageButton()
    {
        await _googleMapsPage.LanguageButton.ClickAsync();
        await _commonPageActions.WaitForConditionToBeTrue(_googleMapsPage.EnglishLanguage.IsVisibleAsync());
    }

    public async Task SelectLanguage(string language)
    {
        switch (language.ToLower()) {
            case "english" : await _googleMapsPage.EnglishLanguage.ClickAsync(); break;
            case "german" : await _googleMapsPage.GermanLanguage.ClickAsync(); break;
            default : throw new ArgumentException($"{language} language option selection has not been implemented yet.");
        }
        await _commonPageActions.WaitForConditionToBeTrue(_googleMapsPage.EnglishLanguage.IsHiddenAsync());
    }
}