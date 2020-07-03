using BlazeReport.Tests.Factories;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace BlazeReport.Tests.Common
{
    /// <summary>
    /// Contains logic for setting up the webdriver.
    /// </summary>
    [Binding]
    public static class WebDriverHooks
    {
        /// <summary>
        /// Before each scenario, create a new IWebDriver for isolation. Only 
        /// scenarios annotaded with @UseWebDriver will make use of one.
        /// </summary>
        [BeforeScenario("UseWebDriver")]
        public static void SetUpWebDriver(ScenarioContext scenarioContext)
        {
            scenarioContext["WEB_DRIVER"] = WebDriverFactory.Default();
        }

        /// <summary>
        /// After each scenario, close the driver for better isolation.
        /// </summary>
        [AfterScenario("UseWebDriver")]
        public static void TearDownWebDriver(ScenarioContext scenarioContext)
        {
            var driver = scenarioContext["WEB_DRIVER"] as IWebDriver;
            driver.Quit();
        }

        /// <summary>
        /// A uniform way of accessing the WebDriver, since the WEB_DRIVER key might
        /// change in the far future.
        /// </summary>
        public static IWebDriver GetDriver(ScenarioContext scenarioContext)
        {
            return scenarioContext["WEB_DRIVER"] as IWebDriver;
        }
    }
}
