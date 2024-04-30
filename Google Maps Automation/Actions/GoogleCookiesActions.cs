namespace GMAutomation;

public class GoogleCookiesActions
{
    private readonly GoogleCookiesPage _googleCookiesPage;
    private readonly CommonPageActions _commonPageActions;

    public GoogleCookiesActions(GoogleCookiesPage googleCookiesPage, CommonPageActions commonPageActions)
    {
        _googleCookiesPage = googleCookiesPage;
        _commonPageActions = commonPageActions;
    }

    public async Task UserDeniesCookies()
    {
        await _googleCookiesPage.DenyCookiesButton.ClickAsync();
    }

    public async Task UserBypassesCookiesPage()
    {
        if(_commonPageActions.GetCurrentURL().Contains("consent.google"))
        {
            await UserDeniesCookies();
            await _commonPageActions.WaitForPageLoad();
        }
    }
}