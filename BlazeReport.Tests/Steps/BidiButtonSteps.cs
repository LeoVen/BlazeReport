using BlazeReport.Tests.Common;
using BlazeReport.Tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using TechTalk.SpecFlow;

namespace BlazeReport.Tests.Steps
{
    [Binding]
    public class BidiButtonSteps
    {
        private readonly IndexPage indexPage;

        public BidiButtonSteps(ScenarioContext scenarioContext)
        {
            indexPage = new IndexPage(WebDriverHooks.GetDriver(scenarioContext));
        }

        [Given(@"I open the index page")]
        public void GivenIOpenTheIndexPage()
        {
            // Goes to index page and sleeps the thread for a while to give a
            // chance for the Blazor page to load
            ActionWaits.PageWait(() => indexPage.OpenIndexPage());
        }

        [Given(@"I click the button")]
        public void GivenIClickTheButton()
        {
            // The webdriver might be too fast and the Blazor component's state
            // might not have enough time to reload, thus making the unit tests
            // unreliable: sometimes failing, others, passing.
            ActionWaits.StateWait(() => indexPage.ClickBidiButton());
        }

        [Given(@"I right click the button")]
        public void GivenIRightClickTheButton()
        {
            ActionWaits.StateWait(() => indexPage.RightClickButton());
        }

        [Then(@"Must have value of (.*)")]
        public void ThenMustHaveValueOf(int value)
        {
            Assert.AreEqual(value, indexPage.GetCounter());
        }
    }
}
