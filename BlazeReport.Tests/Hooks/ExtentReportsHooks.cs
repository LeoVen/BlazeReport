using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using BlazeReport.Tests.Extensions;
using BlazeReport.Tests.Factories;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;

namespace BlazeReport.Tests.Hooks
{
    //[Binding]
    public static class ExtentReportsHooks
    {
        private static ExtentTest feature;
        private static ExtentTest scenario;

		/// List of Reporters
        private static ExtentReports extent;

		/// <summary>
		/// Setup ExtentReports and add a default reporter
		/// </summary>
		[BeforeTestRun]
		public static void BeforeTestRun(TestThreadContext _)
		{
			extent = new ExtentReports();
			extent.AttachReporter(ReportFactory.Default());
		}

		[BeforeFeature]
		public static void BeforeFeature(FeatureContext context)
		{
			feature = extent.CreateTest<Feature>(context.FeatureInfo.Title);
		}

		[BeforeScenario]
		public static void BeforeScenario(ScenarioContext context)
        {
			scenario = feature.CreateNode<Scenario>(context.ScenarioInfo.Title);
		}

		[AfterStep]
		public static void AfterStep(ScenarioStepContext context)
		{
			switch (context.StepInfo.StepDefinitionType)
			{
				case StepDefinitionType.Given:
					scenario.StepDefinitionGiven();
					break;

				case StepDefinitionType.Then:
					scenario.StepDefinitionThen();
					break;

				case StepDefinitionType.When:
					scenario.StepDefinitionWhen();
					break;
			}
		}

		[AfterTestRun]
        public static void AfterTestRun()
        {
            extent.Flush();
            System.Diagnostics.Process.Start(ReportFactory.ReportPath);
        }
    }
}
