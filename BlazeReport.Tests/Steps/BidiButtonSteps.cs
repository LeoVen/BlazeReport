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
            indexPage.OpenIndexPage();
        }

        [Given(@"I click the button")]
        public void GivenIClickTheButton()
        {
            // The page might take a while for loading when it comes from the blazor app server
            Thread.Sleep(1000);
            indexPage.ClickButton();
        }

        [Given(@"I right click the button")]
        public void GivenIRightClickTheButton()
        {
            Thread.Sleep(1000);
            indexPage.RightClickButton();
        }

        [Then(@"Must have value of (.*)")]
        public void ThenMustHaveValueOf(int value)
        {
            int counterValue = indexPage.GetCounter();
            Assert.AreEqual(value, counterValue);
        }
    }
}
