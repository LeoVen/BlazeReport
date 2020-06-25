using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;

namespace BlazeReport.Tests.Common
{
    /// <summary>
    /// Utility class to set up nodes more easily
    /// </summary>
    public class ScenarioStepBuilder
    {
        private readonly ScenarioContext scenario;
        private readonly ExtentTest extent;

        public ScenarioStepBuilder(ExtentTest extent, ScenarioContext scenario)
        {
            this.extent = extent;
            this.scenario = scenario;
        }

        public void StepDefinitionGiven()
        {
            if (scenario.TestError == null)
                CreateScenario(StepDefinitionType.Given);
            else
                CreateScenarioFailOrError(StepDefinitionType.Given);
        }

        public void StepDefinitionWhen()
        {
            if (scenario.TestError == null)
                CreateScenario(StepDefinitionType.When);
            else
                CreateScenarioFailOrError(StepDefinitionType.When);
        }

        public void StepDefinitionThen()
        {
            if (scenario.TestError == null)
                CreateScenario(StepDefinitionType.Then);
            else
                CreateScenarioFailOrError(StepDefinitionType.Then);
        }

        private ExtentTest CreateScenario(StepDefinitionType stepDefinitionType)
        {
            var scenarioStepContext = scenario.StepContext.StepInfo.Text;

            return stepDefinitionType switch
            {
                StepDefinitionType.Given => extent.CreateNode<Given>(scenarioStepContext),
                StepDefinitionType.Then => extent.CreateNode<Then>(scenarioStepContext),
                StepDefinitionType.When => extent.CreateNode<When>(scenarioStepContext),
                _ => throw new ArgumentOutOfRangeException(nameof(stepDefinitionType), stepDefinitionType, null),
            };
        }

        private void CreateScenarioFailOrError(StepDefinitionType stepDefinitionType)
        {
            var error = scenario.TestError;

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
