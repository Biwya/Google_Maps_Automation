using System.Data.Common;
using Microsoft.Playwright;

namespace GMAutomation;

public class GoogleMapsPage
{
    private readonly IPage _page;
    public ILocator PageHtml { get; }
    public ILocator HamburgerMenu { get; }
    public ILocator SettingsMenu { get; }
    public ILocator LanguageButton { get; }
    public ILocator EnglishLanguage { get; }
    public ILocator GermanLanguage { get; }
    public ILocator SearchBox { get; }
    public ILocator SearchButton { get; }
    public ILocator DirectionsButton { get; }
    public ILocator AddressInformation { get; }
    public ILocator DirectionsWindow { get; }
    public ILocator DirectionsStartingPointInput { get; }
    public ILocator DirectionStartingPointSearchButton { get; }
    public ILocator DirectionsDestinationInput { get; }
    public ILocator DirectionsDestinationSearchButton { get; }
    public ILocator TravelByDrivingButton { get; }
    public ILocator TravelByTransitButton { get; }
    public ILocator TravelByFlightButton { get; }
    public ILocator TravelRoutes { get; }

    public GoogleMapsPage(Hooks hooks)
    {
        _page = hooks.Page;
        PageHtml = _page.Locator("//html");
        HamburgerMenu = _page.Locator("//button[@jsaction='navigationrail.more']");
        SettingsMenu = _page.Locator("//ul[@role='menu']");
        LanguageButton = _page.Locator("//button[@jsaction='settings.languages']");
        EnglishLanguage = _page.Locator("//*[contains(text(), 'English (United States)')]");
        GermanLanguage = _page.Locator("//*[contains(text(), 'Deutsch (Deutschland)')]");
        SearchBox = _page.Locator("//input[@id='searchboxinput']");
        SearchButton = _page.Locator("//button[@id='searchbox-searchbutton']");
        DirectionsButton = _page.Locator("//button[@aria-label='Directions']");
        AddressInformation = _page.Locator("//div[@role='main']");
        DirectionsWindow = _page.Locator("//div[@id='omnibox-directions']");
        DirectionsStartingPointInput = _page.Locator("//div[@id='directions-searchbox-0']//input");
        DirectionStartingPointSearchButton = _page.Locator("//div[@id='directions-searchbox-0']//button[@aria-label='Search']");
        DirectionsDestinationInput = _page.Locator("//div[@id='directions-searchbox-1']//input");
        DirectionsDestinationSearchButton = _page.Locator("//div[@id='directions-searchbox-1']//button[@aria-label='Search']");
        TravelByDrivingButton = _page.Locator("//button[./img[@aria-label='Driving']]");
        TravelByTransitButton = _page.Locator("//button[./img[@aria-label='Transit']]");
        TravelByFlightButton = _page.Locator("//button[./img[@aria-label='Flights']]");
        TravelRoutes = _page.Locator("//div[@data-trip-index]");
    }
}