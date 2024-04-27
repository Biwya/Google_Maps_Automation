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

    [When("the user clicks the option to deny cookies")]
    public async Task UserDeniesGoogleCookies()
    {
        await _googleCookiesActions.UserDeniesCookies();
    }

    [Given("the user continues by denying Google cookies")]
    [When("the user continues by denying Google cookies")]
    public async Task UserContinuesByDenyingGoogleCookies()
    {
        await _commonPageSteps.PageLoads();
        await UserDeniesGoogleCookies();
        await _commonPageSteps.PageLoads();
    }

    [When("the user opens the burger menu")]
    public async Task UserOpensBurgerMenu()
    {
        await _googleStepsActions.ClickBurgerMenu();
        _googleStepsActions.CheckSettingsMenuIsVisible();
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
}