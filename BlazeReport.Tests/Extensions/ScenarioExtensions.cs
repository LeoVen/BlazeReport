using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;

namespace BlazeReport.Tests.Extensions
{
    public static class ScenarioExtensions
    {
		private static ExtentTest CreateScenario(ExtentTest extent, StepDefinitionType stepDefinitionType)
		{
			var scenarioStepContext = ScenarioStepContext.Current.StepInfo.Text;

            return stepDefinitionType switch
            {
                StepDefinitionType.Given => extent.CreateNode<Given>(scenarioStepContext),
                StepDefinitionType.Then => extent.CreateNode<Then>(scenarioStepContext),
                StepDefinitionType.When => extent.CreateNode<When>(scenarioStepContext),
                _ => throw new ArgumentOutOfRangeException(nameof(stepDefinitionType), stepDefinitionType, null),
            };
        }

		private static void CreateScenarioFailOrError(ExtentTest extent, StepDefinitionType stepDefinitionType)
		{
			var error = ScenarioContext.Current.TestError;

			if (error.InnerException == null)
			{
				CreateScenario(extent, stepDefinitionType).Error(error.Message);
			}
			else
			{
				CreateScenario(extent, stepDefinitionType).Fail(error.InnerException);
			}
		}

		public static void StepDefinitionGiven(this ExtentTest extent)
		{
			if (ScenarioContext.Current.TestError == null)
				CreateScenario(extent, StepDefinitionType.Given);
			else
				CreateScenarioFailOrError(extent, StepDefinitionType.Given);
		}

		public static void StepDefinitionWhen(this ExtentTest extent)
		{
			if (ScenarioContext.Current.TestError == null)
				CreateScenario(extent, StepDefinitionType.When);
			else
				CreateScenarioFailOrError(extent, StepDefinitionType.When);
		}

		public static void StepDefinitionThen(this ExtentTest extent)
		{
			if (ScenarioContext.Current.TestError == null)
				CreateScenario(extent, StepDefinitionType.Then);
			else
				CreateScenarioFailOrError(extent, StepDefinitionType.Then);
		}
	}
}
