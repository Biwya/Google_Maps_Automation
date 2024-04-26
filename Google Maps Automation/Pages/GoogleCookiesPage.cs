using Microsoft.Playwright;

namespace GMAutomation;

public class GoogleCookiesPage
{
    private readonly IPage _page;
    private readonly IReadOnlyList<ILocator> _buttons;
    public ILocator DenyCookiesButton { get; }
    public ILocator AcceptCookiesButton { get; }

    public GoogleCookiesPage(Hooks hooks)
    {
        _page = hooks.Page;
        _buttons = _page.GetByRole(AriaRole.Button).AllAsync().Result;
        DenyCookiesButton = _buttons.First();
        AcceptCookiesButton = _buttons[1];
    }
}