using System.Data.Common;
using Microsoft.Playwright;

namespace GMAutomation;

public class GoogleMapsPage
{
    private readonly IPage _page;
    public ILocator HamburgerMenu { get; }
    public ILocator SettingsMenu { get; }
    public ILocator LanguageButton { get; }
    public ILocator EnglishLanguage {get;}
    public ILocator GermanLanguage {get; }
    public ILocator SearchBox { get; }
    public ILocator SearchButton { get; }
    public ILocator AddressInformation { get; }

    public GoogleMapsPage(Hooks hooks)
    {
        _page = hooks.Page;
        HamburgerMenu = _page.Locator("//button[@jsaction='navigationrail.more']");
        SettingsMenu = _page.Locator("//ul[@role='menu']");
        LanguageButton = _page.Locator("//button[@jsaction='settings.languages']");
        EnglishLanguage = _page.Locator("//*[contains(text(), 'English (United States)')]");
        GermanLanguage = _page.Locator("//*[contains(text(), 'Deutsch (Deutschland)')]");
        SearchBox = _page.Locator("//input[@id='searchboxinput']");
        SearchButton = _page.Locator("//button[@id='searchbox-searchbutton']");
        AddressInformation = _page.Locator("//div[@role='main']");
    }
}