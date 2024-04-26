using Reqnroll;

namespace GMAutomation;

[Binding]
public class GoogleSteps
{
    private readonly GoogleCookiesActions _googleCookiesActions;
    private readonly GoogleMapsActions  _googleStepsActions;

    public GoogleSteps(GoogleCookiesActions googleCookiesActions, GoogleMapsActions googleStepsActions)
    {
        _googleCookiesActions = googleCookiesActions;
        _googleStepsActions = googleStepsActions;
    }

    [When("the user clicks the option to deny cookies")]
    public async Task userDeniesGoogleCookies()
    {
        await _googleCookiesActions.userDeniesCookies();
    }
}