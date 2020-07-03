using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BlazeReport.Tests.Steps
{
    /// <summary>
    /// A test that doesn't uses a WebDriver
    /// </summary>
    [Binding]
    class MathSteps
    {
        public ScenarioContext ScenarioContext { get; set; }

        public int Sum { get; set; } = 0;
        public int Lhs { get; set; } = 0;
        public int Rhs { get; set; } = 0;

        public MathSteps(ScenarioContext scenarioContext)
        {
            ScenarioContext = scenarioContext;
        }

        [Given(@"I have entered (.*)")]
        public void GivenIHaveEnteredIntoTheCalculator(int value)
        {
            Lhs = value;
        }

        [Given(@"then entered (.*)")]
        public void GivenAndThenEntered(int value)
        {
            Rhs = value;
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            Sum = Lhs + Rhs;
        }

        [Then(@"then result should be (.*)")]
        public void ThenTheResultShouldBeOnTheScreen(int result)
        {
            Assert.AreEqual(result, Sum);
        }
    }
}
