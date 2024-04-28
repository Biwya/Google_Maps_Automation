using System.Diagnostics.CodeAnalysis;
using Microsoft.Playwright;
using NUnit.Framework.Constraints;

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

    public async Task ClearDirectionInput(Direction direction) {
        await InputDirection("", direction);
    }

    public async Task ClickSearchDirection(Direction direction)
    {
        switch (direction)
        {
            case Direction.STARTING_POINT:
                await _googleMapsPage.DirectionStartingPointSearchButton.ClickAsync();
                break;
            case Direction.DESTINATION:
                await _googleMapsPage.DirectionsDestinationSearchButton.ClickAsync();
                break;
            case Direction.LOCATION:
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
        await _commonPageActions.WaitForConditionToBeTrue(_googleMapsPage.TravelRoutes.First.IsVisibleAsync());
    }

    public async void AssertNumberOfRoutes(Comparator comparator, int comparedValue)
    {
        await _commonPageActions.WaitForPageNetworkIdle();
        await _commonPageActions.WaitForConditionToBeTrue(_googleMapsPage.TravelRoutes.First.IsVisibleAsync());
        var travelRoutes = await _googleMapsPage.TravelRoutes.AllAsync();
        int numberOfRoutes = travelRoutes.Count;
        AssertComparisonOfNumericValues(comparator, comparedValue, numberOfRoutes);
    }

    public async void AssertNumberOfSearchResults(Comparator comparator, int comparedValue)
    {
        await _commonPageActions.WaitForPageNetworkIdle();
        await _commonPageActions.WaitForConditionToBeTrue(_googleMapsPage.LocationSearchResults.First.IsVisibleAsync());
        var searchResults = await _googleMapsPage.LocationSearchResults.AllAsync();
        int numberOfSearchResults = searchResults.Count;
        AssertComparisonOfNumericValues(comparator, comparedValue, numberOfSearchResults);
    }

    public async Task ReverseDestinations()
    {
        await _googleMapsPage.ReverseDestinationsButton.ClickAsync();
        await _commonPageActions.WaitForConditionToBeTrue(_googleMapsPage.TravelRoutes.First.IsVisibleAsync());
        await _commonPageActions.WaitForPageNetworkIdle();
    }

    public async Task ClickOnCloseDirectionsScreen()
    {
        await _commonPageActions.WaitForConditionToBeTrue(_googleMapsPage.CloseDirectionsButton.IsVisibleAsync());
        await _googleMapsPage.CloseDirectionsButton.ClickAsync();
        await _commonPageActions.WaitForPageLoad();
    }

    public async Task AssertSeesGeneralSearchInputField()
    {
        await _commonPageActions.WaitForConditionToBeTrue(_googleMapsPage.SearchBox.IsVisibleAsync());
        Assert.That(_googleMapsPage.SearchBox.IsVisibleAsync().Result, Is.True);
    }

    public async Task ClickSearchButton()
    {
        await _commonPageActions.WaitForConditionToBeTrue(_googleMapsPage.SearchButton.IsVisibleAsync());
        await _googleMapsPage.SearchButton.ClickAsync();
        await _commonPageActions.WaitForConditionToBeTrue(_googleMapsPage.LocationSearchResults.First.IsVisibleAsync());
    }

    public async Task OpenSearchFilters()
    {
        await _commonPageActions.WaitForConditionToBeTrue(_googleMapsPage.SearchFiltersButton.IsVisibleAsync());
        await _googleMapsPage.SearchFiltersButton.ClickAsync();
        await _commonPageActions.WaitForConditionToBeTrue(_googleMapsPage.RatingFilterSection.IsVisibleAsync());
    }

    public async Task SelectRatingFilter(float starRating)
    {
        await _googleMapsPage.RatingFilterButton.ClickAsync();
        switch (starRating)
        {
            case 2.0f: await _googleMapsPage.RatingSelectionMenu.Locator("//div[@data-index='1']").ClickAsync(); break;
            case 2.5f: await _googleMapsPage.RatingSelectionMenu.Locator("//div[@data-index='2']").ClickAsync(); break;
            case 3.0f: await _googleMapsPage.RatingSelectionMenu.Locator("//div[@data-index='3']").ClickAsync(); break;
            case 3.5f: await _googleMapsPage.RatingSelectionMenu.Locator("//div[@data-index='4']").ClickAsync(); break;
            case 4.0f: await _googleMapsPage.RatingSelectionMenu.Locator("//div[@data-index='5']").ClickAsync(); break;
            case 4.5f: await _googleMapsPage.RatingSelectionMenu.Locator("//div[@data-index='6']").ClickAsync(); break;
            default: throw new ArgumentException($"Invalid or not accounted for star rating of {starRating}");
        }
        await _commonPageActions.WaitForConditionToBeTrue(_googleMapsPage.RatingFilterButton.IsVisibleAsync());
        var selectedStarRating = await _googleMapsPage.RatingFilterButton.Locator("//span[@aria-label]").GetAttributeAsync("aria-label");
        Assert.That(selectedStarRating.Contains(starRating.ToString()), Is.True);
    }

    public async Task ConfirmFilteringOptions()
    {
        await _commonPageActions.WaitForConditionToBeTrue(_googleMapsPage.FilteringDoneButton.IsVisibleAsync());
        await _googleMapsPage.FilteringDoneButton.ClickAsync();
        await _commonPageActions.WaitForPageNetworkIdle();
        await _commonPageActions.WaitForConditionToBeTrue(_googleMapsPage.SearchBox.IsVisibleAsync());
    }

    public async Task AssertRatingOfEachLocation(Comparator comparator, float starRating)
    {
        await _commonPageActions.WaitForConditionToBeTrue(_googleMapsPage.LocationSearchResults.First.IsVisibleAsync());
        var availableLocations = await _googleMapsPage.LocationSearchResults.AllAsync();
        for (int i = 0; i < availableLocations.Count; i++)
        {
            string locationRatingText = await availableLocations[i].Locator("//span[contains(@aria-label, 'stars')]").GetAttributeAsync("aria-label");
            float locationRating = Convert.ToSingle(locationRatingText.Substring(0,3));
            AssertComparisonOfNumericValues(comparator, starRating, locationRating);
        }
    }

    public async Task ClickOnCloseSearchLocationButton()
    {
        await _commonPageActions.WaitForConditionToBeTrue(_googleMapsPage.CloseSearchLocationButton.IsVisibleAsync());
        await _googleMapsPage.CloseSearchLocationButton.ClickAsync();
        await _commonPageActions.WaitForConditionToBeTrue(_googleMapsPage.DirectionsButton.First.IsVisibleAsync());
    }

    private void AssertComparisonOfNumericValues(Comparator comparator, IComparable expectedValue, IComparable actualValue) 
    {
        switch (comparator)
        {
            case Comparator.IS:
            case Comparator.EQUAL_TO:
            case Comparator.EXACTLY: Assert.That(actualValue, Is.EqualTo(expectedValue), $"{actualValue} did not match the expected {expectedValue}"); break;
            case Comparator.AT_LEAST: Assert.That(actualValue, Is.AtLeast(expectedValue), $"{actualValue} is not equal or more than the expected {expectedValue}"); break;
            case Comparator.AT_MOST: Assert.That(actualValue, Is.AtMost(expectedValue), $"{actualValue} is not equal or less than the expected {expectedValue}"); break;
            default: throw new ArgumentException($"{comparator} is not valid or was not accounted for numeric comparison of routes");
        }
    }
}