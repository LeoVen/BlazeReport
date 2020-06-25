using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using BlazeReport.Tests.Common;
using BlazeReport.Tests.Factories;
using System;
using System.Diagnostics;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;

namespace BlazeReport.Tests.Hooks
{
    [Binding]
    public static class ExtentReportsHooks
    {
		/// Temporary variables for holding the current feature and scenario tests
        private static ExtentTest feature;
        private static ExtentTest scenario;

		/// List of Reporters
        private static AventStack.ExtentReports.ExtentReports extent;

		/// <summary>
		/// Setup ExtentReports and add a default reporter
		/// </summary>
		[BeforeTestRun]
		public static void BeforeTestRun()
		{
			extent = new AventStack.ExtentReports.ExtentReports();
			extent.AttachReporter(ReportFactory.Default());
		}

		/// <summary>
		/// Create a test for each feature
		/// </summary>
		[BeforeFeature]
		public static void BeforeFeature(FeatureContext context)
		{
			feature = extent.CreateTest<Feature>(context.FeatureInfo.Title);
		}

		/// <summary>
		/// Create a scenario node for each scenario inside a feature
		/// </summary>
		[BeforeScenario]
		public static void BeforeScenario(ScenarioContext context)
        {
			scenario = feature.CreateNode<Scenario>(context.ScenarioInfo.Title);
		}

		[AfterStep]
		public static void AfterStep(ScenarioContext scenarioContext)
		{
			var builder = new ScenarioStepBuilder(scenario, scenarioContext);

			switch (scenarioContext.StepContext.StepInfo.StepDefinitionType)
			{
				case StepDefinitionType.Given:
					builder.StepDefinitionGiven();
					break;
				case StepDefinitionType.When:
					builder.StepDefinitionWhen();
					break;
				case StepDefinitionType.Then:
					builder.StepDefinitionThen();
					break;
			}
		}

		/// <summary>
		/// Save extent report and open it
		/// </summary>
		[AfterTestRun]
        public static void AfterTestRun()
        {
            extent.Flush();
			Process.Start(@"cmd.exe ", @$"/c {ReportFactory.ReportPath}index.html");
        }
    }
}
