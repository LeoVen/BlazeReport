using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BlazeReport.Tests.Factories
{
    public static class WebDriverFactory
    {
        public static IWebDriver Default()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");

            return new ChromeDriver(options);
        }
    }
}
