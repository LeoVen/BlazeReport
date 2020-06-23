using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using BlazeReport.Tests.Extensions;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;

namespace BlazeReport.Tests.Common
{
    [Binding]
    public class Hooks
    {
        private static ExtentTest feature;
        private static ExtentTest scenario;
        private static ExtentReports extent;

        private static readonly string ReportPath = $"{AppDomain.CurrentDomain.BaseDirectory}ExtentBlazeReport.html";

		[BeforeTestRun]
		public static void ConfigureReport()
		{
			var reporter = new ExtentHtmlReporter(ReportPath);
			extent = new ExtentReports();
			extent.AttachReporter(reporter);
		}

		[BeforeFeature]
		public static void CreateFeature()
		{
			feature = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
		}

		[BeforeScenario]
		public static void CreateScenario()
		{
			scenario = feature.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
		}

		[AfterStep]
		public static void InsertReportingSteps()
		{
			switch (ScenarioStepContext.Current.StepInfo.StepDefinitionType)
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
		public static void FlushExtent()
		{
			extent.Flush();
			System.Diagnostics.Process.Start(ReportPath);
		}
	}
}
