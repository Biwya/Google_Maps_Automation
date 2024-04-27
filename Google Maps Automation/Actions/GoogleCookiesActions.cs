namespace GMAutomation;

public class GoogleCookiesActions
{
    private readonly GoogleCookiesPage _googleCookiesPage;

    public GoogleCookiesActions(GoogleCookiesPage googleCookiesPage)
    {
        _googleCookiesPage = googleCookiesPage;
    }

    public async Task UserDeniesCookies()
    {
        await _googleCookiesPage.DenyCookiesButton.ClickAsync();
    }
}