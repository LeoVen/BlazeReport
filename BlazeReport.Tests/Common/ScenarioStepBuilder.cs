using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;

namespace BlazeReport.Tests.Common
{
    /// <summary>
    /// Utility class to set up nodes more easily
    /// </summary>
    public class ScenarioStepBuilder
    {
        private readonly ScenarioContext scenarioContext;
        private readonly ExtentTest scenario;

        public ScenarioStepBuilder(ExtentTest scenario, ScenarioContext scenarioContext)
        {
            this.scenario = scenario;
            this.scenarioContext = scenarioContext;
        }

        public void StepDefinitionGiven()
        {
            if (scenarioContext.TestError == null)
                CreateScenario(StepDefinitionType.Given);
            else
                CreateScenarioFailOrError(StepDefinitionType.Given);
        }

        public void StepDefinitionWhen()
        {
            if (scenarioContext.TestError == null)
                CreateScenario(StepDefinitionType.When);
            else
                CreateScenarioFailOrError(StepDefinitionType.When);
        }

        public void StepDefinitionThen()
        {
            if (scenarioContext.TestError == null)
                CreateScenario(StepDefinitionType.Then);
            else
                CreateScenarioFailOrError(StepDefinitionType.Then);
        }

        private ExtentTest CreateScenario(StepDefinitionType stepDefinitionType)
        {
            var stepText = scenarioContext.StepContext.StepInfo.Text;

            return stepDefinitionType switch
            {
                StepDefinitionType.Given => scenario.CreateNode<Given>(stepText),
                StepDefinitionType.Then => scenario.CreateNode<Then>(stepText),
                StepDefinitionType.When => scenario.CreateNode<When>(stepText),
                _ => throw new ArgumentOutOfRangeException(nameof(stepDefinitionType), stepDefinitionType, null),
            };
        }

        private void CreateScenarioFailOrError(StepDefinitionType stepDefinitionType)
        {
            var error = scenarioContext.TestError;

            if (error.InnerException == null)
            {
                CreateScenario(stepDefinitionType).Error(error.Message);
            }
            else
            {
                CreateScenario(stepDefinitionType).Fail(error.InnerException);
            }
        }
    }
}
