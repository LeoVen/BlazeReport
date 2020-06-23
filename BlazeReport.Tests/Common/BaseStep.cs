using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace BlazeReport.Tests.Common
{
    public class BaseStep : IDisposable
    {
        protected IWebDriver Driver { get; }

        public BaseStep(IObjectContainer objectContainer)
        {
            objectContainer.RegisterInstanceAs(new ChromeDriver(), typeof(IWebDriver));
            Driver = objectContainer.Resolve<IWebDriver>();
        }

        public void Dispose()
        {
            Driver?.Quit();
            Driver?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
