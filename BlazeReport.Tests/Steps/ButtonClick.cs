using BlazeReport.Tests.Common;
using BlazeReport.Tests.Pages;
using BoDi;
using NUnit.Framework;
using System.Threading;
using TechTalk.SpecFlow;

namespace BlazeReport.Tests.Steps
{
    [Binding]
    public sealed class ButtonClick : BaseStep
    {
        private readonly IndexPage indexPage;

        public ButtonClick(IObjectContainer objectContainer) : base(objectContainer)
        {
            indexPage = new IndexPage(this.Driver);
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

        [When(@"I wait for state change")]
        public void WhenIWaitForStateChange()
        {
            // The state might take a while to update
            Thread.Sleep(1000);
        }

        [Then(@"Must have value of (.*)")]
        public void ThenMustHaveValueOf(int value)
        {
            int counterValue = indexPage.GetCounter();
            Assert.AreEqual(value, counterValue);
        }
    }
}
