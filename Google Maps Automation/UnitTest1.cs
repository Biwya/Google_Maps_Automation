using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace Google_Maps_Automation;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest
{

    ScenarioContext scenarioContext = ScenarioContext.GetInstance();

    [Test]
    public async Task CheckContext()
    {
        IPage Page = await base.Context.NewPageAsync().ConfigureAwait(continueOnCapturedContext: false);
        scenarioContext.Save(ContextKeys.PAGE, Page);
        IPage CheckedPage = scenarioContext.Get(ContextKeys.PAGE);
        Assert.NotNull(CheckedPage);
        await CheckedPage.GotoAsync("https://playwright.dev");
        await Expect(CheckedPage).ToHaveTitleAsync(new Regex("Playwright"));
    }
}