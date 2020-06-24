using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;

namespace BlazeReport.Tests.Pages
{
    public class IndexPage
    {
        private readonly IWebDriver webDriver;

        public IndexPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public void OpenIndexPage()
        {
            // Where the blazor app is launched
            webDriver.Navigate().GoToUrl(@"https://localhost:44350/");
        }

        public void ClickButton()
        {
            var clickButton = webDriver.FindElement(By.Id("clicker"));
            clickButton.Click();
        }

        public void RightClickButton()
        {
            Actions actions = new Actions(webDriver);
            var clickButton = webDriver.FindElement(By.Id("clicker"));
            actions.ContextClick(clickButton).Perform();
        }

        public int GetCounter()
        {
            var counterValue = webDriver.FindElement(By.Id("counter")).Text;
            return string.IsNullOrEmpty(counterValue) ? 0 : Convert.ToInt32(counterValue);
        }
    }
}
