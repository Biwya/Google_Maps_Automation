namespace GMAutomation;

public class GoogleCookiesActions
{
    private readonly GoogleCookiesPage _googleCookiesPage;

    public GoogleCookiesActions(GoogleCookiesPage googleCookiesPage)
    {
        _googleCookiesPage = googleCookiesPage;
    }

    public async Task userDeniesCookies()
    {
        await _googleCookiesPage.DenyCookiesButton.ClickAsync();
    }
}