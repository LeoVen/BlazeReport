# Blaze Report

A minimal example of a Blazor App with:

* [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)
* [NUnit](https://nunit.org/)
* [Selenium](https://www.selenium.dev/)
* [SpecFlow](https://specflow.org/)
* [ExtentReports](http://extentreports.com/)

## Projects

* BlazeReport.Commons - A Blazor Class Library
* BlazeReport.Tests - A NUnit Test Project
* BlazeReport.Web - A Blazor App

## Blazor

The page `Index.razor` has a single component:

* BidiButton - A button that can be clicked or right-clicked

## Selenium

* WebDriver - A web driver, in this case, Chrome

## Specflow

__Structure__

SpecFlow uses Gherkin which supports Behaviour-Driven-Design, and has the following structure:

* A test may contain many Features.
* A Feature may contain many Scenarios.
* A Scenario may contain many Scenario Blocks (Given, When, And, But)
* A Scenario Block may contain many Steps

__Bindings__

* BeforeTestRun / AfterTestRun             - Runs before/after the entire test run
* BeforeFeature / AfterFeature             - Runs before/after a feature
* BeforeScenario / AfterScenario           - Runs before/after a scenario
* BeforeScenarioBlock / AfterScenarioBlock - Runs before/after blocks of Given, When, Then
* BeforeStep / AfterStep                   - Runs before/after a step

## ExtentReports

A report is created before the test run (BeforeTestRun) and after all tests, it is saved to `C:\Dev\ExtentReport`. Each __Feature__ is a __Test__ and each __Scenario__ is a __Node__.
