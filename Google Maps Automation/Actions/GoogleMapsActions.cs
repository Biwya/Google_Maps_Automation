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
    }

    public async Task AssertSettingsMenuIsVisible()
    {
        await _commonPageActions.WaitForConditionToBeTrue(_googleMapsPage.SettingsMenu.IsVisibleAsync());
        Assert.That(_googleMapsPage.SettingsMenu.IsVisibleAsync().Result, Is.True);
    }

    public async Task ClickLanguageButton()
    {
        await _googleMapsPage.LanguageButton.ClickAsync();
        await _commonPageActions.WaitForConditionToBeTrue(_googleMapsPage.EnglishLanguage.IsVisibleAsync());
    }

    public async Task SelectLanguage(string language)
    {
        switch (language.ToLower())
        {
            case "english": await _googleMapsPage.EnglishLanguage.ClickAsync(); break;
            case "german": await _googleMapsPage.GermanLanguage.ClickAsync(); break;
            default: throw new ArgumentException($"{language} language option selection has not been implemented yet.");
        }
        await _commonPageActions.WaitForConditionToBeTrue(_googleMapsPage.EnglishLanguage.IsHiddenAsync());
    }

    public bool CheckPageDisplayLanguage(string language)
    {
        string languageId;
        switch (language.ToLower())
        {
            case "english": languageId = "en"; break;
            case "german": languageId = "de"; break;
            default: throw new ArgumentException($"The page cannot be chacked for the following language {language};");
        }
        return _googleMapsPage.PageHtml.GetAttributeAsync("lang").Result.Contains(languageId);
    }

    public void AssertPageLanguageDisplayed(string language, bool displayed)
    {
        Assert.That(CheckPageDisplayLanguage(language), Is.EqualTo(displayed));
    }

    public async Task GoogleMapsToBeDisplayedIn(string language)
    {
        await ClickBurgerMenu();
        if (!CheckPageDisplayLanguage(language))
        {
            await AssertSettingsMenuIsVisible();
            await ClickLanguageButton();
            await SelectLanguage(language);
            AssertPageLanguageDisplayed(language, true);
        }
    }

    public async Task OpenDirectionsWindow()
    {
        await _googleMapsPage.DirectionsButton.ClickAsync();
        await _commonPageActions.WaitForConditionToBeTrue(_googleMapsPage.DirectionsWindow.IsVisibleAsync());
        Assert.Multiple(() =>
        {
            Assert.That(_googleMapsPage.DirectionsWindow.IsVisibleAsync().Result, Is.True);
            Assert.That(_googleMapsPage.DirectionsStartingPointInput.IsVisibleAsync().Result, Is.True);
            Assert.That(_googleMapsPage.DirectionsDestinationInput.IsVisibleAsync().Result, Is.True);
        });
    }

    public async Task InputDirection(string location, Direction direction)
    {
        switch (direction)
        {
            case Direction.STARTING_POINT: await _googleMapsPage.DirectionsStartingPointInput.FillAsync(location); break;
            case Direction.DESTINATION: await _googleMapsPage.DirectionsDestinationInput.FillAsync(location); break;
            case Direction.LOCATION: await _googleMapsPage.SearchBox.FillAsync(location); break;
            default: throw new ArgumentException($"There is no valid input field with the following direction type: {direction}");
        }
    }

    public async Task ClickSearchDirection(Direction direction)
    {
        switch (direction)
        {
            case Direction.STARTING_POINT:
                await _googleMapsPage.DirectionsStartingPointInput.ClickAsync();
                await _googleMapsPage.DirectionStartingPointSearchButton.ClickAsync();
                break;
            case Direction.DESTINATION:
                await _googleMapsPage.DirectionsDestinationInput.ClickAsync();
                await _googleMapsPage.DirectionsDestinationSearchButton.ClickAsync();
                break;
            case Direction.LOCATION:
                await _googleMapsPage.SearchBox.ClickAsync();
                await _googleMapsPage.SearchButton.ClickAsync();
                break;
            default:
                throw new ArgumentException($"There is no valid search button to be clicked for direction of {direction}");
        }
    }

    public async Task SelectTransportationOption(TransportationOption transportationOption)
    {
        switch (transportationOption)
        {
            case TransportationOption.DRIVING: await _googleMapsPage.TravelByDrivingButton.ClickAsync(); break;
            case TransportationOption.TRANSIT: await _googleMapsPage.TravelByTransitButton.ClickAsync(); break;
            case TransportationOption.FLIGHT: await _googleMapsPage.TravelByFlightButton.ClickAsync(); break;
            default: throw new ArgumentException($"{transportationOption} is not defined/implemented to be selected by the user");
        }
        await _commonPageActions.WaitForConditionToBeTrue(_googleMapsPage.TravelRoutes.IsVisibleAsync());
    }

    public async void AssertNumberOfRoutes(Comparator comparator, int comparedValue)
    {
        await _commonPageActions.WaitForPageNetworkIdle();
        var travelRoutes = await _googleMapsPage.TravelRoutes.AllAsync();
        int numberOfRoutes = travelRoutes.Count;
        switch (comparator)
        {
            case Comparator.IS:
            case Comparator.EQUAL_TO:
            case Comparator.EXACTLY: Assert.That(comparedValue, Is.EqualTo(numberOfRoutes), $"{numberOfRoutes} did not match the expected {comparedValue}"); break;
            case Comparator.AT_LEAST: Assert.That(numberOfRoutes, Is.AtLeast(comparedValue), $"{numberOfRoutes} is not equal or more than the expected {comparedValue}"); break;
            case Comparator.AT_MOST: Assert.That(numberOfRoutes, Is.AtMost(comparedValue), $"{numberOfRoutes} is not equal or less than the expected {comparedValue}"); break;
            default: throw new ArgumentException($"{comparator} is not valid or was not accounted for numeric comparison of routes");
        }
    }
}