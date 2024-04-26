using Microsoft.Playwright;

namespace GMAutomation;

public class GoogleMapsPage
{
    private readonly IPage _page;

    public GoogleMapsPage(Hooks hooks) 
    {
        _page = hooks.Page;
    }
}