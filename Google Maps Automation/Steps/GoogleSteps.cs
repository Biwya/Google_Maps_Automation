using Reqnroll;

namespace GMAutomation;

[Binding]
public class GoogleSteps
{
    private readonly GoogleCookiesActions _googleCookiesActions;
    private readonly GoogleMapsActions _googleStepsActions;
    private readonly CommonPageSteps _commonPageSteps;

    public GoogleSteps(GoogleCookiesActions googleCookiesActions, GoogleMapsActions googleStepsActions, CommonPageSteps commonPageSteps)
    {
        _googleCookiesActions = googleCookiesActions;
        _googleStepsActions = googleStepsActions;
        _commonPageSteps = commonPageSteps;
    }

    [Given("google maps is displayed in {string}")]
    public async Task GoogleMapsDisplayedIn(string language)
    {
        await _googleStepsActions.GoogleMapsToBeDisplayedIn(language);
    }

    [Given("the user continues by denying Google cookies")]
    [When("the user continues by denying Google cookies")]
    public async Task UserContinuesByDenyingGoogleCookies()
    {
        await _commonPageSteps.PageLoads();
        await UserDeniesGoogleCookies();
        await _commonPageSteps.PageLoads();
    }

    [When("the user clicks the option to deny cookies")]
    public async Task UserDeniesGoogleCookies()
    {
        await _googleCookiesActions.UserDeniesCookies();
    }

    [When("the user opens the burger menu")]
    public async Task UserOpensBurgerMenu()
    {
        await _googleStepsActions.ClickBurgerMenu();
        await _googleStepsActions.AssertSettingsMenuIsVisible();
    }

    [When("the user clicks on the Language button")]
    public async Task UserClicksLanguageButton()
    {
        await _googleStepsActions.ClickLanguageButton();
    }

    [When("the user selects the {string} language")]
    public async Task UserSelectsLanguageOption(string language)
    {
        await _googleStepsActions.SelectLanguage(language);
    }

    [When("the user clicks on Directions button")]
    public async Task UserClicksOnDirectionsButton()
    {
        await _googleStepsActions.OpenDirectionsWindow();
    }

    [When("the user inputs {string} location as {}")]
    public async Task UserInputsLocationAsDirection(string location, Direction direction)
    {
        await _googleStepsActions.InputDirection(location, direction);
    }

    [When("the user clears the {} location")]
    public async Task UserClearsLocationInput(Direction direction)
    {
        await _googleStepsActions.ClearDirectionInput(direction);
    }

    [When("the user selects {} transportation option")]
    public async Task UserSelectsTransportationOption(TransportationOption transportationOption)
    {
        await _googleStepsActions.SelectTransportationOption(transportationOption);
    }

    [When("the user reverses the starting point and destination locations")]
    public async Task UserReversesStartingPointAndDestination()
    {
        await _googleStepsActions.ReverseDestinations();
    }

    [When("the user closes the directions screen")]
    public async Task UserClosesDirectionsScreen()
    {
        await _googleStepsActions.ClickOnCloseDirectionsScreen();
    }

    [When("the user clicks on Search button")]
    public async Task UserClicksOnSearchButton()
    {
        await _googleStepsActions.ClickSearchButton();
    }

    [When("the user opens the search filters")]
    public async Task UserOpensSearchFilters()
    {
        await _googleStepsActions.OpenSearchFilters();
    }

    [When("the user filters by rating of {float} stars")]
    public async Task UserFiltersByRatingOfStars(float starRating)
    {
        await _googleStepsActions.SelectRatingFilter(starRating);
    }

    [When("the user confirms the filtering options")]
    public async Task UserCOnfirmsFilteringOptions()
    {
        await _googleStepsActions.ConfirmFilteringOptions();
    }

    [When("the user closes the search location screen")]
    public async Task UserClosesSearchLocationScreen()
    {
        await _googleStepsActions.ClickOnCloseSearchLocationButton();
    }

    [When("the user clicks on the {} direction search button")]
    public async Task UserClicksOnDirectionSearchButton(Direction direction)
    {
        await _googleStepsActions.ClickSearchDirection(direction);
    }

    [Then("the page is displayed in {string} language")]
    public void CheckPageLanguage(string language)
    {
        _googleStepsActions.AssertPageLanguageDisplayed(language, true);
    }

    [Then("the user sees {} {int} route(s)")]
    public async Task UserSeesNumberOfRoutes(Comparator comparator, int numberOfRoutes)
    {
        await _googleStepsActions.AssertNumberOfRoutes(comparator, numberOfRoutes);
    }

    [Then("the user sees {} {int} search results")]
    public async Task UserSeesNumberOfSearchResults(Comparator comparator, int numberOfSearchResults)
    {
        await _googleStepsActions.AssertNumberOfSearchResults(comparator, numberOfSearchResults);
    }

    [Then("the user sees the general search input field")]
    public async Task UserSeesGeneralSearchInputField()
    {
        await _googleStepsActions.AssertSeesGeneralSearchInputField();
    }

    [Then("all locations have the rating of {} {float} stars")]
    public async Task AllLocationsHaveRating(Comparator comparator, float numberOfStars)
    {
        await _googleStepsActions.AssertRatingOfEachLocation(comparator, numberOfStars);
    }
}