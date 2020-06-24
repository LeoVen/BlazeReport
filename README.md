# Blaze Report

A minimal example of a Blazor App with:

* Blazor
* NUnit
* Selenium
* SpecFlow
* ExtentReports

## Specflow

__Structure__

SpecFlow uses Gherkin which supports Behaviour-Driven-Design, and has the following structure:

* A test may contain many Features.
* A Feature may contain many Scenarios.
* A Scenario may contain many Scenario Blocks (Given, When, And, But)
* A Scenario Blcok may contain many Steps

__Bindings__

* BeforeTestRun / AfterTestRun             - Runs before/after the entire test run
* BeforeFeature / AfterFeature             - Runs before/after a feature
* BeforeScenario / AfterScenario           - Runs before/after a scenario
* BeforeScenarioBlock / AfterScenarioBlock - Runs before/after blocks of Given, When, Then
* BeforeStep / AfterStep                   - Runs before/after a step
