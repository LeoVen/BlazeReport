using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;

namespace BlazeReport.Tests.Pages
{
    public class IndexPage
    {
        private readonly string buttonId = "clicker";
        private readonly string counterId = "counter";

        private readonly IWebDriver webDriver;

        public IWebElement ClickButton => webDriver.FindElement(By.Id(buttonId));

        public IWebElement Counter => webDriver.FindElement(By.Id(counterId));

        public IndexPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public void OpenIndexPage()
        {
            // Where the blazor app is launched
            webDriver.Navigate().GoToUrl(@"https://localhost:44350/");
        }

        public void ClickBidiButton()
        {
            ClickButton.Click();
        }

        public void RightClickButton()
        {
            Actions actions = new Actions(webDriver);
            actions.ContextClick(ClickButton).Perform();
        }

        public int GetCounter()
        {
            var counterText = Counter.Text;
            return string.IsNullOrEmpty(counterText) ? 0 : Convert.ToInt32(counterText);
        }
    }
}
