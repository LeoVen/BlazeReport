using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace BlazeReport.Tests.Steps
{
    [Binding]
    public class UtilitySteps
    {
        public UtilitySteps() { }

        [Given(@"I wait for (.*) ms")]
        public void GivenIWaitForMs(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }

        [When(@"I wait for (.*) ms")]
        public void WhenIWaitForMs(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }
    }
}
